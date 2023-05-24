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
            .Include(x => x.Employee)
            .Include(x => x.Flats)
            .ThenInclude(x => x.Rooms)
            // filter starts here
            .Where(x =>
                (filter.BuildingName == null || x.BuildingName.ToLower().Contains(filter.BuildingName.ToLower()))
                && (filter.Description == null || x.Description.ToLower().Contains(filter.Description.ToLower()))
                && (filter.BuildingAddress == null ||
                    x.BuildingAddress.ToLower().Contains(filter.BuildingAddress.ToLower()))
                && (filter.TotalFlats == null || x.TotalFlats == filter.TotalFlats)
                && (filter.Status == null || x.Status == filter.Status)
                && (filter.BuildingPhoneNumber == null || x.BuildingPhoneNumber.Contains(filter.BuildingPhoneNumber))
                && (filter.EmployeeName == null ||
                    x.Employee.Username.ToLower().Contains(filter.EmployeeName.ToLower()))
                && (filter.AreaName == null || x.Area.Name.ToLower().Contains(filter.AreaName.ToLower()))
                && (filter.AveragePrice == null || x.AveragePrice <= filter.AveragePrice)
                && (filter.SpareSlots == null ||
                    x.Flats.Any(flat => flat.Rooms.Any(room => room.AvailableSlots > 0))))
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
            .Include(x => x.Employee)
            .ThenInclude(x => x.Role)
            .Where(x => x.BuildingId == buildingId);
    }

    /// <summary>
    ///     AddExpenseHistory new building to database
    /// </summary>
    /// <param name="building"></param>
    /// <param name="employeeId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> AddBuildingAndItsManagement(Building building, int employeeId)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var isEmployeeFree =
                await _context.Buildings
                    .FirstOrDefaultAsync(x => x.EmployeeId == building.EmployeeId && x.Status == true);

            if (isEmployeeFree != null)
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Quản lí này đang quản lí tòa nhà khác"
                };

            await _context.Buildings.AddAsync(building);

            var employeeCheck = await _context.Employees
                .FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

            if (employeeCheck is null)
            {
                await transaction.RollbackAsync();
                return new RepositoryResponse
                {
                    IsSuccess = false,
                    Message = "Nhân viên không tồn tại"
                };
            }

            employeeCheck.SupervisorBuildingId = building.BuildingId;

            _context.Attach(employeeCheck).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Toà nhà đã được tạo thành công"
            };
        }
        catch
        {
            await transaction.RollbackAsync();

            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Tạo mới tòa nhà thất bại"
            };
        }
    }

    /// <summary>
    ///     UpdateExpenseHistory building detail using building id
    /// </summary>
    /// <param name="building"></param>
    /// <param name="number"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdateBuildingImages(Building building, int number)
    {
        var buildingData = await _context.Buildings
            .FirstOrDefaultAsync(x => x.BuildingId == building.BuildingId);

        if (buildingData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Toà nhà không tồn tại"
            };

        switch (number)
        {
            case 1:
                buildingData.BuildingImageUrl1 = building.BuildingImageUrl1;
                break;
            case 2:
                buildingData.BuildingImageUrl2 = building.BuildingImageUrl2;
                break;
            case 3:
                buildingData.BuildingImageUrl3 = building.BuildingImageUrl3;
                break;
            case 4:
                buildingData.BuildingImageUrl4 = building.BuildingImageUrl4;
                break;
            case 5:
                buildingData.BuildingImageUrl5 = building.BuildingImageUrl5;
                break;
            case 6:
                buildingData.BuildingImageUrl6 = building.BuildingImageUrl6;
                break;
        }

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Building image updated successfully"
        };
    }

    public async Task<RepositoryResponse> UpdateBuilding(Building? building)
    {
        var buildingData = await _context.Buildings
            .FirstOrDefaultAsync(x => building != null && x.BuildingId == building.BuildingId);

        if (buildingData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Toà nhà không tồn tại"
            };

        var count = _context.Flats
            .Count(x => building != null && x.BuildingId == building.BuildingId);

        buildingData.BuildingName = building?.BuildingName ?? buildingData.BuildingName;
        buildingData.BuildingAddress = building?.BuildingAddress ?? buildingData.BuildingAddress;
        buildingData.Description = building?.Description ?? buildingData.Description;
        buildingData.TotalFlats = count;
        buildingData.AveragePrice = building.AveragePrice;
        buildingData.Status = building.Status;
        buildingData.BuildingPhoneNumber = building.BuildingPhoneNumber;
        buildingData.AreaId = building.AreaId;
        buildingData.BuildingImageUrl1 = building.BuildingImageUrl1 ?? buildingData.BuildingImageUrl1;
        buildingData.BuildingImageUrl2 = building.BuildingImageUrl2 ?? buildingData.BuildingImageUrl2;
        buildingData.BuildingImageUrl3 = building.BuildingImageUrl3 ?? buildingData.BuildingImageUrl3;
        buildingData.BuildingImageUrl4 = building.BuildingImageUrl4 ?? buildingData.BuildingImageUrl4;
        buildingData.BuildingImageUrl5 = building.BuildingImageUrl5 ?? buildingData.BuildingImageUrl5;
        buildingData.BuildingImageUrl6 = building.BuildingImageUrl6 ?? buildingData.BuildingImageUrl6;

        _context.Attach(buildingData).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Building updated successfully"
        };
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
                Message = "Toà nhà không tồn tại"
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