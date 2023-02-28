using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Flat
{
    public Flat()
    {
        FeedBacks = new HashSet<Feedback>();
        Contracts = new HashSet<Contract>();
        Rooms = new HashSet<Room>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FlatId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int? WaterMeterBefore { get; set; }
    public int? ElectricityMeterBefore { get; set; }
    public int? WaterMeterAfter { get; set; }
    public int? ElectricityMeterAfter { get; set; }
    public int MaxRoom { get; set; }
    public int AvailableRoom { get; set; }
    public int FlatTypeId { get; set; }
    public virtual FlatType FlatType { get; set; }
    public int BuildingId { get; set; }
    public virtual Building Building { get; set; }
    public virtual ICollection<Room> Rooms { get; set; }
    public virtual ICollection<Feedback> FeedBacks { get; set; }
    public virtual ICollection<Contract> Contracts { get; set; }
}