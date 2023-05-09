using System.Globalization;
using Domain.ViewModel.ContractEntity;
using Domain.ViewModel.EmployeeEntity;
using Domain.ViewModel.ImageUrls;
using Domain.ViewModel.TicketTypeEntity;

namespace Domain.ViewModel.TicketEntity;

public class TicketDetailEntity
{
    public int TicketId { get; set; }
    public string TicketName { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }

    public string CreatedDateReturn
        => CreateDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public DateTime? SolveDate { get; set; }

    public string? SolveDateReturn
        => SolveDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public decimal? Amount { get; set; }
    public string Status { get; set; }
    public string? CancelledReason { get; set; }
    public List<TicketImageUrlViewModel>? ImageUrls { get; set; }
    public int ContractId { get; set; }
    public ContractBasicDetailEntity Contract { get; set; }
    public int EmployeeId { get; set; }
    public EmployeeBasicDetailEntity Employee { get; set; }
    public int TicketTypeId { get; set; }
    public TicketTypeDetailEntity TicketType { get; set; }
}