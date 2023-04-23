/*
using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class RoomTypeService : IRoomTypeService
{
    private readonly PaginationOption _paginationOption;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RoomTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOption)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOption = paginationOption.Value;
    }


    public Task<PagedList<RoomType>?> GetRoomTypes(RoomTypeFilter filters, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<RoomType?> GetRoomTypeDetail(int roomTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<RoomType?> AddRoomType(RoomType roomType)
    {
        throw new NotImplementedException();
    }

    public Task<RepositoryResponse> UpdateRoomType(RoomType roomType)
    {
        throw new NotImplementedException();
    }

    public Task<RepositoryResponse> DeleteRoomType(int roomTypeId)
    {
        throw new NotImplementedException();
    }
}

*/

