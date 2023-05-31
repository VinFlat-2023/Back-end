using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Metric;
using Domain.QueryFilter;
using Domain.ViewModel.MetricNumber;

namespace Service.IService;

public interface IFlatService
{
    public Task<PagedList<Flat>?> GetFlatList(FlatFilter filter, CancellationToken token);
    public Task<PagedList<Flat>?> GetFlatList(FlatFilter filter, int buildingId, CancellationToken token);
    public Task<Flat?> GetFlatById(int? flatId, int buildingId, CancellationToken token);
    public Task<RepositoryResponse> AddFlat(Flat flat, List<int> roomTypeId, CancellationToken token);
    public Task<RepositoryResponse> UpdateFlat(Flat flat);
    public Task<RepositoryResponse> DeleteFlat(int flatId);
    public Task<RepositoryResponse> GetRoomInAFlat(int flatId, CancellationToken token);
    public Task<List<Flat>?> GetFlatList(int buildingId, CancellationToken token);
    public Task<MetricNumberForTotal?> GetTotalWaterAndElectricity(int buildingId, CancellationToken token);

    public Task<MetricNumberForTotal?> GetTotalWaterAndElectricityByFlat(int flatId, int buildingId,
        CancellationToken token);

    public Task<RepositoryResponse> SetTotalWaterAndElectricityByFlat(UpdateMetricRequest request, int flatId,
        int buildingId, CancellationToken token);

    public Task<int?> GetTotalFlatBasedOnFilter(MetricFlatFilter request, int buildingId, CancellationToken token);
}