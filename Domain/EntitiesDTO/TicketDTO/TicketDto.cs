using System.Text.Json.Serialization;
using Domain.EntitiesDTO.AccountDTO;
using Domain.EntitiesDTO.ContractDTO;
using Domain.EntitiesDTO.TicketTypeDTO;

namespace Domain.EntitiesDTO.TicketDTO;

public class TicketDto
{
    public int TicketId { get; set; }
    public string TicketName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public DateTime? SolveDate { get; set; }
    public decimal? Amount { get; set; }

    public string Status { get; set; } = null!;

    // Contract
    public int ContractId { get; set; }

    [JsonIgnore] public virtual ContractDto Contract { get; set; } = null!;

    // Management
    public int AccountId { get; set; }
    [JsonIgnore] public virtual AccountDto Account { get; set; } = null!;
    public int TicketTypeId { get; set; }
    [JsonIgnore] public virtual TicketTypeDto TicketType { get; set; } = null!;
}