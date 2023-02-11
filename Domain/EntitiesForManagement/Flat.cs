using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Flat
{
    public Flat()
    {
        FeedBacks = new HashSet<Feedback>();
        Contracts = new HashSet<Contract>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FlatId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int? WaterMeter { get; set; }
    public int? ElectricityMeter { get; set; }
    public int FlatTypeId { get; set; }
    public virtual FlatType FlatType { get; set; }
    public int BuildingId { get; set; }
    public virtual Building Building { get; set; }
    public virtual ICollection<Feedback> FeedBacks { get; set; }
    public virtual ICollection<Contract> Contracts { get; set; }
    public virtual ICollection<Room> Rooms { get; set; }
}