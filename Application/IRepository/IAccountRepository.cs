using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IAccountRepository
{
    public IQueryable<Account> GetAccountList(AccountFilter filters);
    public Task<Account?> IsAccountUsernameExist(string username);
    public IQueryable<Account> GetAccountDetail(int? accountId);
    public Task<Account> AddAccount(Account account);
    public Task<Account?> UpdateAccount(Account account);
    public Task<bool> ToggleAccount(int accountId);
    public Task<bool> DeleteAccount(int accountId);
    public IQueryable<Account> GetAccount(string username, string password);
    public Task<Account?> IsAccountEmailExist(string email);
    public Task<Account?> GetAccountByUserName(string userName);
}