using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class AccountService : IAccountService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public AccountService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Account>?> GetAccountList(AccountFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Accounts.GetAccountList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Account>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<Account?> GetAccountById(int? accountId)
    {
        return await _repositoryWrapper.Accounts.GetAccountDetail(accountId)
            .FirstOrDefaultAsync();
    }

    public async Task<Account?> GetSupervisorAccount(int accountId)
    {
        return await _repositoryWrapper.Accounts.GetAccountDetail(accountId)
            .Where(x => x.Role.RoleName == "Supervisor")
            .FirstOrDefaultAsync();
    }

    public async Task<Account?> AddAccount(Account account)
    {
        return await _repositoryWrapper.Accounts.AddAccount(account);
    }

    public async Task<Account?> UpdateAccount(Account account)
    {
        return await _repositoryWrapper.Accounts.UpdateAccount(account);
    }

    public async Task<bool> ToggleAccountStatus(int accountId)
    {
        return await _repositoryWrapper.Accounts.ToggleAccount(accountId);
    }

    public async Task<bool> DeleteAccount(int accountId)
    {
        return await _repositoryWrapper.Accounts.DeleteAccount(accountId);
    }

    public async Task<Account?> IsAccountUsernameExist(string? username)
    {
        return await _repositoryWrapper.Accounts.IsAccountUsernameExist(username);
    }

    public async Task<Account?> IsAccountEmailExist(string? email)
    {
        return await _repositoryWrapper.Accounts.IsAccountEmailExist(email);
    }

    public async Task<Account?> AccountLogin(string username, string password)
    {
        return await _repositoryWrapper.Accounts.GetAccount(username, password)
            .FirstOrDefaultAsync();
    }
}