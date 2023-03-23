using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationContext _context;

    public AccountRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get list of all account available in the database
    /// </summary>
    /// <returns></returns>
    public IQueryable<Account> GetAccountList(AccountFilter filters)
    {
        return _context.Accounts
            .Include(x => x.Role)
            // Filter starts here
            .Where(x =>
                (filters.Username == null || x.Username.Contains(filters.Username))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.RoleId == null || x.RoleId == filters.RoleId)
                && (filters.FullName == null || x.FullName.Contains(filters.FullName))
                && (filters.Phone == null || x.Phone.Contains(filters.Phone)))
            .AsNoTracking();
    }

    public async Task<Account?> IsAccountEmailExist(string email)
    {
        return await _context.Accounts
            .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
    }

    public async Task<Account?> IsAccountUsernameExist(string username)
    {
        return await _context.Accounts
            .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));
    }

    /// <summary>
    ///     Get account details by Id
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public IQueryable<Account> GetAccountDetail(int? accountId)
    {
        return _context.Accounts
            .Where(a => a.AccountId == accountId);
    }

    /// <summary>
    ///     AddExpenseHistory new account
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public async Task<Account> AddAccount(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
        return account;
    }

    /// <summary>
    ///     UpdateExpenseHistory account status
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdateAccount(Account account)
    {
        var accountData = await _context.Accounts
            .FirstOrDefaultAsync(x => x.AccountId == account.AccountId);

        if (accountData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Account not found"
            };

        accountData.Email = account.Email;
        accountData.Password = account.Password;
        accountData.Phone = account.Phone;
        accountData.Username = account.Username;
        accountData.FullName = account.FullName;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Account updated successfully"
        };
    }
    
    public async Task<RepositoryResponse> UpdateAccountPassword(Account? account)
    {
        var accountData = await _context.Accounts
            .FirstOrDefaultAsync(x => x.AccountId == account!.AccountId);

        if (accountData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Account not found"
            };
        
        accountData.Password = account?.Password ?? accountData.Password;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Account password updated successfully"
        };    
    }

    /// <summary>
    ///     Toggle account status
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> ToggleAccount(int accountId)
    {
        var accountFound = await _context.Accounts
            .FirstOrDefaultAsync(x => x.AccountId == accountId);

        if (accountFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Account not found"
            };

        accountFound.Status = !accountFound.Status;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Account status updated successfully"
        };  
    }

    /// <summary>
    ///     DeleteExpenseHistory account by Id
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteAccount(int accountId)
    {
        var accountFound = await _context.Accounts
            .FirstOrDefaultAsync(x => x.AccountId == accountId);
        
        if (accountFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Account not found"
            };
        
        _context.Accounts.Remove(accountFound);
        await _context.SaveChangesAsync();
        
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Account deleted successfully"
        };  
    }

    /// <summary>
    ///     Get account based on username and password
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public IQueryable<Account> GetAccount(string username, string password)
    {
        return _context.Accounts
            .Where(a => a.Username == username && a.Password == password)
            .Include(b => b.Role);
    }

    public async Task<Account?> GetAccountByUserName(string userName)
    {
        return await _context.Accounts
            .Where(a => a.Username == userName)
            .Include(b => b.Role).FirstOrDefaultAsync();
    }

    /// <summary>
    ///     Get a list of account containing the query string
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public IQueryable<Account> GetAccountListContainName(string name)
    {
        return _context.Accounts.Where(a => string.Equals(a.Username, name,
            StringComparison.CurrentCultureIgnoreCase));
    }
}