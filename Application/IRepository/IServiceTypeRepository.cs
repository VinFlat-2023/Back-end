﻿using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IServiceTypeRepository
{
    public IQueryable<ServiceType> GetServiceTypeList(ServiceTypeFilter filters);
    public IQueryable<ServiceType> GetServiceTypeDetail(int? serviceTypeId);
    public Task<ServiceType> AddServiceType(ServiceType serviceType);
    public Task<RepositoryResponse> UpdateServiceType(ServiceType serviceType);
    public Task<RepositoryResponse> DeleteServiceType(int serviceTypeId);
}