using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class TicketType
{
    public TicketType()
    {
        Tickets = new HashSet<Ticket>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TicketTypeId { get; set; }

    public string TicketTypeName { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; }
}