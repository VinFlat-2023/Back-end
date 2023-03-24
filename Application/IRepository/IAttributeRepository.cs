using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IAttributeRepository
{
    public IQueryable<AttributeForNumeric> GetAttributeList(AttributeForNumericFilter numericFilter);
    public IQueryable<AttributeForNumeric> GetAttributeById(int? attributeForNumericId);
    public Task<AttributeForNumeric> AddAttribute(AttributeForNumeric attribute);
    public Task<RepositoryResponse> UpdateAttribute(AttributeForNumeric attribute);
    public Task<RepositoryResponse> DeleteAttribute(int attributeForNumericId);
}