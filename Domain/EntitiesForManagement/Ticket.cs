using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Ticket
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TicketId { get; set; }

    public string TicketName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public DateTime? SolveDate { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; } = null!;

    // Contract
    // Management
    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    //public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = null!;
    public int TicketTypeId { get; set; }
    public virtual TicketType TicketType { get; set; } = null!;
}