using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IAccountService
{
    public Task<PagedList<Account>?> GetAccountList(AccountFilter filter, CancellationToken token);
    public Task<Account?> GetAccountById(int? accountId);
    public Task<Account?> AddAccount(Account account);
    public Task<Account?> UpdateAccount(Account account);
    public Task<bool> ToggleAccountStatus(int accountId);
    public Task<bool> DeleteAccount(int accountId);
    public Task<Account?> IsAccountEmailExist(string? email);
    public Task<Account?> IsAccountUsernameExist(string? email);
    public Task<Account?> AccountLogin(string username, string password);
    public Task<Account?> GetSupervisorAccount(int accountId);
    public Task<Account> UpdatePasswordAccount(Account updatePasswordAccount);
}