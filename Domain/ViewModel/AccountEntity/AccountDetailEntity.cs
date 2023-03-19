using Domain.ViewModel.RoleEntity;

namespace Domain.ViewModel.AccountEntity;

public class AccountDetailEntity
{
    public int AccountId { get; set; }
    public string Username { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Status { get; set; }
    public RoleDetailEntity Role { get; set; }
}