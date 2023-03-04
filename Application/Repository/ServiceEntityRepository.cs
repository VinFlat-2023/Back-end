using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class ServiceEntityRepository : IServiceEntityRepository
{
    private readonly ApplicationContext _context;

    public ServiceEntityRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all services
    /// </summary>
    /// <returns></returns>
    public IQueryable<ServiceEntity> GetServiceList(ServiceEntityFilter filters)
    {
        return _context.Services
            .Include(x => x.ServiceType)
            .Where(x => x.ServiceTypeId == x.ServiceType.ServiceTypeId)
            // Filter starts here
            .Where(x =>
                (filters.Name == null || x.Name.Contains(filters.Name))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.ServiceTypeId == null || x.ServiceTypeId == filters.ServiceTypeId)
                && (filters.Description == null || x.Description.Contains(filters.Description)))
            .AsNoTracking();
    }

    public IQueryable<ServiceEntity> GetServiceList(ServiceEntityFilter filters, int buildingId)
    {
        return _context.Services
            .Include(x => x.ServiceType)
            .Where(x => x.ServiceTypeId == x.ServiceType.ServiceTypeId)
            .Where(x => x.BuildingId == buildingId)
            // Filter starts here
            .Where(x =>
                (filters.Name == null || x.Name.Contains(filters.Name))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.ServiceTypeId == null || x.ServiceTypeId == filters.ServiceTypeId)
                && (filters.Description == null || x.Description.Contains(filters.Description)))
            .AsNoTracking();
    }

    private async Task<int?> GetBuildingId(int renterId)
    {
        var contract = await _context.Contracts.FirstOrDefaultAsync(x => x.RenterId == renterId);

        if (contract == null)
            return null;
        
        return await _context.Contracts
            .Where(x => x.ContractId == contract.ContractId)
            .Select(x => x.BuildingId)
            .FirstOrDefaultAsync();
    }

    public IQueryable<ServiceEntity> GetServiceList(int renterId, ServiceEntityFilter filters)
    {
        var buildingId = GetBuildingId(renterId).Result;
        
        return _context.Services
            .Include(x => x.ServiceType)
            .Where(x => x.ServiceTypeId == x.ServiceType.ServiceTypeId)
            .Where(x => x.BuildingId == buildingId)
            // Filter starts here
            .Where(x =>
                (filters.Name == null || x.Name.Contains(filters.Name))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.ServiceTypeId == null || x.ServiceTypeId == filters.ServiceTypeId)
                && (filters.Description == null || x.Description.Contains(filters.Description)))
            .AsNoTracking();    
    }

    /// <summary>
    ///     Get serviceEntity by id
    /// </summary>
    /// <param name="serviceId"></param>
    /// <returns></returns>
    public IQueryable<ServiceEntity> GetServiceDetail(int? serviceId)
    {
        return _context.Services
            .Where(x => x.ServiceId == serviceId);
    }

    /// <summary>
    ///     AddFeedback new serviceEntity
    /// </summary>
    /// <param name="serviceEntity"></param>
    /// <returns></returns>
    public async Task<ServiceEntity> AddService(ServiceEntity serviceEntity)
    {
        await _context.Services.AddAsync(serviceEntity);
        await _context.SaveChangesAsync();
        return serviceEntity;
    }

    /// <summary>
    ///     UpdateFeedback serviceEntity
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public async Task<ServiceEntity?> UpdateService(ServiceEntity? service)
    {
        var serviceData = await _context.Services
            .Where(x => x.ServiceId == service!.ServiceId)
            .FirstOrDefaultAsync();

        if (serviceData == null)
            return null;

        serviceData.ServiceTypeId = service?.ServiceTypeId ?? serviceData.ServiceTypeId;
        serviceData.Name = service?.Name ?? serviceData.Name;
        serviceData.Description = service?.Description ?? serviceData.Description;
        serviceData.Status = service?.Status ?? serviceData.Status;
        serviceData.Amount = service?.Amount ?? serviceData.Amount;

        await _context.SaveChangesAsync();
        return serviceData;
    }

    /// <summary>
    ///     DeleteFeedback serviceEntity
    /// </summary>
    /// <param name="serviceId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteService(int serviceId)
    {
        var serviceFound = await _context.Services
            .FirstOrDefaultAsync(x => x.ServiceId == serviceId);
        if (serviceFound == null)
            return false;
        _context.Services.Remove(serviceFound);
        await _context.SaveChangesAsync();
        return true;
    }

   
}