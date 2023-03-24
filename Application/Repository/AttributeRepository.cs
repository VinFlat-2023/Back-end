using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class AttributeRepository : IAttributeRepository
{
    private readonly ApplicationContext _context;

    public AttributeRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<AttributeForNumeric> GetAttributeList(AttributeForNumericFilter filters)
    {
        return _context.AttributeForNumerics
            // Filter starts here
            .Where(x =>
                filters.ElectricityAttribute == null || 
                x.ElectricityAttribute.ToLower().Equals(filters.ElectricityAttribute.ToLower())
                && filters.ElectricityAttribute == null || 
                x.ElectricityAttribute.ToLower().Equals(filters.ElectricityAttribute.ToLower()))
            .AsNoTracking();
    }

    public IQueryable<AttributeForNumeric> GetAttributeById(int? attributeForNumericId)
    {
        return _context.AttributeForNumerics
            .Where(x => x.AttributeForNumericId == attributeForNumericId);
    }

    public async Task<AttributeForNumeric> AddAttribute(AttributeForNumeric attribute)
    {
        await _context.AttributeForNumerics.AddAsync(attribute);
        await _context.SaveChangesAsync();
        return attribute;
    }

    public async Task<RepositoryResponse> UpdateAttribute(AttributeForNumeric attribute)
    {
        var attributeData = await _context.AttributeForNumerics
            .FirstOrDefaultAsync(x => x.AttributeForNumericId == attribute.AttributeForNumericId);

        if (attributeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Attribute not found"
            };

        attributeData.WaterAttribute = attributeData.WaterAttribute;
        attributeData.ElectricityAttribute = attributeData.ElectricityAttribute;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Attribute updated successfully"
        };
    }

    public async Task<RepositoryResponse> DeleteAttribute(int attributeForNumericId)
    {
        var attributeData = await _context.AttributeForNumerics
            .FirstOrDefaultAsync(x => x.AttributeForNumericId == attributeForNumericId);

        if (attributeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Attribute not found"
            };

        _context.AttributeForNumerics.Remove(attributeData);

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Attribute deleted successfully"
        };
    }
}