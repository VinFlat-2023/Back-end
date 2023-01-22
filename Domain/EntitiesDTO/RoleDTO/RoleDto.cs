using Domain.EntitiesDTO.AccountDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.RoleDTO;

public class RoleDto
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public bool Status { get; set; }

    [JsonIgnore] public virtual ICollection<AccountDto> Accounts { get; set; }
}