using Application.IRepository;
using Domain.CustomEntities;
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
            .Include(x => x.Building)
            .ThenInclude(x => x.Employee)
            // filter starts here
            .Where(x =>
                (filters.Name == null || x.Name.ToLower().Contains(filters.Name.ToLower()))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.Price == null || x.Price == filters.Price)
                && (filters.BuildingId == null || x.BuildingId == filters.BuildingId)
                && (filters.BuildingName == null ||
                    x.Building.BuildingName.ToLower().Contains(filters.BuildingName.ToLower()))
                && (filters.ServiceTypeId == null || x.ServiceTypeId == filters.ServiceTypeId)
                && (filters.ServiceTypeName == null ||
                    x.ServiceType.Name.ToLower().Contains(filters.ServiceTypeName.ToLower()))
                && (filters.Description == null || x.Description.ToLower().Contains(filters.Description.ToLower())))
            .AsNoTracking();
    }

    public IQueryable<ServiceEntity> GetServiceList(ServiceEntityFilter filters, int? buildingId)
    {
        return _context.Services
            .Include(x => x.Building)
            .Include(x => x.ServiceType)
            .Where(x => x.BuildingId == buildingId)
            // filter starts here
            .Where(x =>
                (filters.Name == null || x.Name.ToLower().Contains(filters.Name.ToLower()))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.ServiceTypeId == null || x.ServiceTypeId == filters.ServiceTypeId)
                && (filters.Description == null || x.Description.ToLower().Contains(filters.Description.ToLower())))
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
    public async Task<RepositoryResponse> UpdateService(ServiceEntity service)
    {
        var serviceData = await _context.Services
            .Where(x => x.ServiceId == service.ServiceId)
            .FirstOrDefaultAsync();

        if (serviceData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Service not found"
            };

        serviceData.ServiceTypeId = service.ServiceTypeId;
        serviceData.Name = service.Name;
        serviceData.Description = service.Description;
        serviceData.Status = service.Status;
        serviceData.Price = service.Price;

        _context.Attach(serviceData).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Service updated successfully"
        };
    }

    /// <summary>
    ///     DeleteFeedback serviceEntity
    /// </summary>
    /// <param name="serviceId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteService(int serviceId)
    {
        var serviceFound = await _context.Services
            .FirstOrDefaultAsync(x => x.ServiceId == serviceId);
        if (serviceFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Service not found"
            };
        _context.Services.Remove(serviceFound);
        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Service deleted successfully"
        };
    }
}