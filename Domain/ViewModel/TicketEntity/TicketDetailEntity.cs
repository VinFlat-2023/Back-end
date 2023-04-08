using Domain.ViewModel.ContractEntity;
using Domain.ViewModel.EmployeeEntity;
using Domain.ViewModel.TicketTypeEntity;

namespace Domain.ViewModel.TicketEntity;

public class TicketDetailEntity
{
    public int TicketId { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? SolveDate { get; set; }
    public decimal? Amount { get; set; }
    public string Status { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageUrl2 { get; set; }
    public string? ImageUrl3 { get; set; }
    public int ContractId { get; set; }
    public ContractBasicDetailEntity Contract { get; set; }
    public int EmployeeId { get; set; }
    public EmployeeBasicDetailEntity Employee { get; set; }
    public int TicketTypeId { get; set; }
    public TicketTypeDetailEntity TicketType { get; set; }
}