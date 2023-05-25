using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Metric;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IFlatRepository
{
    public IQueryable<Flat> GetFlatList(FlatFilter filters);
    public IQueryable<Flat> GetFlatList(FlatFilter filters, int buildingId);
    public IQueryable<int> GetTotalFlatBasedOnFilter(MetricFlatFilter filters, int buildingId);
    public IQueryable<Flat> GetFlatDetail(int? flatId, int buildingId);
    public Task<RepositoryResponse> GetRoomInAFlat(int flatId, CancellationToken token);
    public Task<RepositoryResponse> AddFlat(Flat flat, List<int> roomTypeId, CancellationToken cancellationToken);
    public Task<RepositoryResponse> UpdateFlat(Flat flat);
    public Task<RepositoryResponse> DeleteFlat(int flatId);
    public IQueryable<Flat> GetFlatList(int buildingId);
    public Task<MetricNumber?> GetTotalWaterAndElectricity(int buildingId, CancellationToken token);
    public Task<MetricNumber?> GetTotalWaterAndElectricityByFlat(int flatId, int buildingId, CancellationToken token);

    public Task<RepositoryResponse> SetTotalWaterAndElectricityByFlat(UpdateMetricRequest request,
        int flatId, int buildingId, CancellationToken token);
}