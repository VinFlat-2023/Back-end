using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class RequestType
{
    public RequestType()
    {
        Requests = new HashSet<Request>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RequestTypeId { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
}