using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IAttributeForNumericService
{
    public Task<PagedList<AttributeForNumeric>?> GetAttributeList(AttributeForNumericFilter numericFilter,
        CancellationToken token);

    public Task<AttributeForNumeric?> GetAttributeById(int? attributeForNumericId);
    public Task<AttributeForNumeric?> AddAttribute(AttributeForNumeric attribute);
    public Task<RepositoryResponse> UpdateAttribute(AttributeForNumeric attribute);
    public Task<RepositoryResponse> DeleteAttribute(int attributeForNumericId);
}