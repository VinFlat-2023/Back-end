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
    public int TotalRooms { get; set; }
    public string ImageUrl { get; set; }
    public decimal CoordinateX { get; set; }
    public decimal CoordinateY { get; set; }
    public string BuildingPhoneNumber { get; set; }
    public bool Status { get; set; }
    // Management Company
    public int AccountId { get; set; }
    public virtual Account Account { get; set; }
    [ForeignKey("AreaId")] public int AreaId { get; set; }
    public virtual Area Area { get; set; }
    public virtual ICollection<Flat> Flats { get; set; }
}