﻿using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IAreaRepository
{
    public IQueryable<Area> GetAreaList(AreaFilter filters);
    public Task<Area?> GetAreaById(int? areaId, CancellationToken cancellationToken);
    public Task<Area?> AddArea(Area area);
    public Task<RepositoryResponse> UpdateArea(Area? area);
    public Task<RepositoryResponse> ToggleArea(int areaId);
    public Task<RepositoryResponse> DeleteArea(int areaId);
    public Task<RepositoryResponse> UpdateAreaImage(Area updateArea, int number);
    public Task<RepositoryResponse> GetAreaByName(string? areaName, CancellationToken token);
    public Task<RepositoryResponse> GetAreaByName(string? areaName, int? areaId, CancellationToken cancellationToken1);
    public IQueryable<Area> GetAreaList();
}