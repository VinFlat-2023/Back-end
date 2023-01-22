using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class ServiceTypeRepository : IServiceTypeRepository
{
    private readonly ApplicationContext _context;

    public ServiceTypeRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all serviceEntity types
    /// </summary>
    /// <returns></returns>
    public IQueryable<ServiceType> GetServiceTypeList(ServiceTypeFilter filters)
    {
        return _context.ServiceTypes
            .Where(x =>
                (filters.Name == null || x.Name.Contains(filters.Name))
                && (filters.Status == null || x.Status == filters.Status))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get serviceEntity type by id
    /// </summary>
    /// <param name="serviceTypeId"></param>
    /// <returns></returns>
    public IQueryable<ServiceType> GetServiceTypeDetail(int? serviceTypeId)
    {
        return _context.ServiceTypes
            .Where(x => x.ServiceTypeId == serviceTypeId);
    }

    /// <summary>
    ///     AddFeedback new serviceEntity type
    /// </summary>
    /// <param name="serviceType"></param>
    /// <returns></returns>
    public async Task<ServiceType> AddServiceType(ServiceType serviceType)
    {
        await _context.ServiceTypes.AddAsync(serviceType);
        await _context.SaveChangesAsync();
        return serviceType;
    }

    /// <summary>
    ///     UpdateFeedback serviceEntity type by id
    /// </summary>
    /// <param name="serviceType"></param>
    /// <returns></returns>
    public async Task<ServiceType?> UpdateServiceType(ServiceType? serviceType)
    {
        var serviceTypeData = await _context.ServiceTypes
            .FirstOrDefaultAsync(x => x.ServiceTypeId == serviceType!.ServiceTypeId);
        if (serviceTypeData == null)
            return null;

        serviceTypeData.Name = serviceType?.Name ?? serviceTypeData.Name;
        serviceTypeData.ServiceTypeId = serviceType?.ServiceTypeId ?? serviceTypeData.ServiceTypeId;

        await _context.SaveChangesAsync();
        return serviceTypeData;
    }

    /// <summary>
    ///     DeleteFeedback serviceEntity type by id
    /// </summary>
    /// <param name="serviceTypeId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteServiceType(int serviceTypeId)
    {
        var serviceTypeFound = await _context.ServiceTypes
            .FirstOrDefaultAsync(x => x.ServiceTypeId == serviceTypeId);
        if (serviceTypeFound == null)
            return false;
        _context.ServiceTypes.Remove(serviceTypeFound);
        await _context.SaveChangesAsync();
        return true;
    }
}