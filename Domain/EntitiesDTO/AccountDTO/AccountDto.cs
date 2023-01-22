using Domain.EntitiesDTO.InvoiceDTO;
using Domain.EntitiesDTO.RoleDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.AccountDTO;

public class AccountDto
{
    public int AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool Status { get; set; }

    public int RoleId { get; set; }

    public virtual RoleDto Role { get; set; }

    [JsonIgnore] public virtual ICollection<InvoiceDto> Invoices { get; set; }
}