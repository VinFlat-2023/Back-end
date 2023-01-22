using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Building
{
    public Building()
    {
        Flats = new HashSet<Flat>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BuildingId { get; set; }

    public string BuildingName { get; set; }
    public string Description { get; set; }
    public int TotalFloor { get; set; }

    // TODO : Add more properties about price per water / electricity / gas / etc
    // TODO : Total rooms = Total rooms created in building
    public int TotalRooms { get; set; }
    public int CoordinateX { get; set; }
    public int CoordinateY { get; set; }
    public bool Status { get; set; }

    // Management Company
    public int AccountId { get; set; }

    [ForeignKey("AreaId")] public int AreaId { get; set; }

    public Area Area { get; set; }
    public virtual ICollection<Flat> Flats { get; set; }
}