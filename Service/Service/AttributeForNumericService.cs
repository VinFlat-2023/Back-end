using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class AttributeForNumericService : IAttributeForNumericService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public AttributeForNumericService(IRepositoryWrapper repositoryWrapper,
        IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }


    public async Task<PagedList<AttributeForNumeric>?> GetAttributeList(AttributeForNumericFilter filters,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.Attributes.GetAttributeList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<AttributeForNumeric>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<AttributeForNumeric?> GetAttributeById(int? attributeId)
    {
        return await _repositoryWrapper.Attributes.GetAttributeById(attributeId)
            .FirstOrDefaultAsync();    
    }

    public async Task<AttributeForNumeric?> AddAttribute(AttributeForNumeric attribute)
    {
        return await _repositoryWrapper.Attributes.AddAttribute(attribute);
    }

    public async Task<RepositoryResponse> UpdateAttribute(AttributeForNumeric attribute)
    {
        return await _repositoryWrapper.Attributes.UpdateAttribute(attribute);
    }

    public async Task<RepositoryResponse> DeleteAttribute(int attributeId)
    {
        return await _repositoryWrapper.Attributes.DeleteAttribute(attributeId);
        
    }
}