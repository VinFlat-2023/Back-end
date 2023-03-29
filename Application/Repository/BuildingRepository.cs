using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class BuildingRepository : IBuildingRepository
{
    private readonly ApplicationContext _context;

    public BuildingRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get a list of building
    /// </summary>
    /// <returns></returns>
    public IQueryable<Building> GetBuildingList(BuildingFilter filter)
    {
        return _context.Buildings
            .Include(x => x.Area)
            .Include(x => x.Account)
            .ThenInclude(x => x.Role)
            // Filter starts here
            .Where(x =>
                (filter.BuildingName == null || x.BuildingName.ToLower().Contains(filter.BuildingName.ToLower()))
                && (filter.Description == null || x.Description.ToLower().Contains(filter.Description.ToLower()))
                && (filter.BuildingAddress == null || x.BuildingAddress.ToLower().Contains(filter.BuildingAddress.ToLower()))
                && (filter.TotalRooms == null || x.TotalRooms == filter.TotalRooms)
                && (filter.Status == null || x.Status == filter.Status)
                && (filter.BuildingPhoneNumber == null || x.BuildingPhoneNumber.Contains(filter.BuildingPhoneNumber))
                && (filter.AccountName == null || x.Account.Username.ToLower().Contains(filter.AccountName.ToLower()))
                && (filter.AreaName == null || x.Area.Name.ToLower().Contains(filter.AreaName.ToLower())))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get building detail using building id
    /// </summary>
    /// <param name="buildingId"></param>
    /// <returns></returns>
    public IQueryable<Building?> GetBuildingDetail(int? buildingId)
    {
        return _context.Buildings
            .Include(x => x.Area)
            .Include(x => x.Account)
            .ThenInclude(x => x.Role)
            .Where(x => x.BuildingId == buildingId);
    }

    /// <summary>
    ///     AddExpenseHistory new building to database
    /// </summary>
    /// <param name="building"></param>
    /// <returns></returns>
    public async Task<Building?> AddBuilding(Building building)
    {
        await _context.Buildings.AddAsync(building);
        await _context.SaveChangesAsync();
        return building;
    }

    /// <summary>
    ///     UpdateExpenseHistory building detail using building id
    /// </summary>
    /// <param name="building"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdateBuilding(Building building)
    {
        var buildingData = await _context.Buildings
            .FirstOrDefaultAsync(x => x.BuildingId == building.BuildingId);

        if (buildingData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Building not found"
            };

        var count = _context.Flats
            .Count(x => x.BuildingId == building.BuildingId);

        buildingData.Description = building.Description;
        buildingData.Status = building.Status;
        buildingData.CoordinateX = building.CoordinateX;
        buildingData.CoordinateY = building.CoordinateY;
        buildingData.ImageUrl = building.ImageUrl;
        buildingData.TotalRooms = count;
        buildingData.BuildingAddress = buildingData.BuildingAddress;
        buildingData.BuildingName = building.BuildingName;
        buildingData.BuildingPhoneNumber = building.BuildingPhoneNumber;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Building updated successfully"
        };
        ;
    }

    /// <summary>
    ///     DeleteExpenseHistory building using building id
    /// </summary>
    /// <param name="buildingId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteBuilding(int buildingId)
    {
        var buildingFound = await _context.Buildings
            .FirstOrDefaultAsync(x => x.BuildingId == buildingId);

        if (buildingFound == null)

            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Building failed to delete"
            };

        _context.Buildings.Remove(buildingFound);

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Building deleted successfully"
        };
    }
}