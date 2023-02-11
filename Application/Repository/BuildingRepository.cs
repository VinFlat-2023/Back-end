using Application.IRepository;
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
            .Where(x => x.AreaId == x.Area.AreaId)
            // Filter starts here
            .Where(x =>
                (filter.BuildingName == null || x.BuildingName.Contains(filter.BuildingName))
                && (filter.Status == null || x.Status == filter.Status)
                && (filter.TotalFloor == null || x.TotalFloor == filter.TotalFloor)
                && (filter.TotalRooms == null || x.TotalRooms == filter.TotalRooms)
                && (filter.AreaId == null || x.AreaId == filter.AreaId)
                && (filter.AccountId == null || x.AccountId == filter.AccountId))
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
    public async Task<Building?> UpdateBuilding(Building? building)
    {
        var buildingData = await _context.Buildings
            .FirstOrDefaultAsync(x => x.BuildingId == building!.BuildingId);
        if (buildingData == null)
            return null;

        buildingData.Description = building?.Description ?? buildingData.Description;
        buildingData.Status = building?.Status ?? buildingData.Status;
        buildingData.CoordinateX = building?.CoordinateX ?? buildingData.CoordinateX;
        buildingData.CoordinateY = building?.CoordinateY ?? buildingData.CoordinateY;
        buildingData.TotalFloor = building?.TotalFloor ?? buildingData.TotalFloor;
        // TODO : Check if total room is not larger than total flats available
        buildingData.TotalRooms = building?.TotalRooms ?? buildingData.TotalRooms;
        buildingData.BuildingName = building?.BuildingName ?? buildingData.BuildingName;

        await _context.SaveChangesAsync();

        return buildingData;
    }

    /// <summary>
    ///     DeleteExpenseHistory building using building id
    /// </summary>
    /// <param name="buildingId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteBuilding(int buildingId)
    {
        var buildingFound = await _context.Buildings
            .FirstOrDefaultAsync(x => x.BuildingId == buildingId);
        if (buildingFound == null || buildingFound.Status)
            return false;
        _context.Buildings.Remove(buildingFound);
        await _context.SaveChangesAsync();
        return true;
    }
}