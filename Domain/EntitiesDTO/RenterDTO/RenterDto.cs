using Domain.EntitiesDTO.ContractDTO;
using Domain.EntitiesDTO.FeedbackDTO;
using Domain.EntitiesDTO.InvoiceDTO;
using Domain.EntitiesDTO.MajorDTO;
using Domain.EntitiesDTO.UniversityDTO;
using Domain.EntitiesForManagement;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.RenterDTO;

public class RenterDto
{
    public int RenterId { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? FullName { get; set; }

    public DateTime? BirthDate { get; set; }

    public bool? Status { get; set; }

    public string? ImageUrl { get; set; }

    public string? CitizenNumber { get; set; }

    public string? CitizenImageUrl { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public int? MajorId { get; set; }

    public virtual MajorDto? Major { get; set; }

    public int? UniversityId { get; set; }

    public virtual UniversityDto? University { get; set; }

    public string? DeviceToken { get; set; }

    [JsonIgnore] public virtual ICollection<UserDevice>? UserDevices { get; set; }

    [JsonIgnore] public virtual ICollection<ContractDto>? Contract { get; set; }

    [JsonIgnore] public virtual ICollection<InvoiceDto>? Invoices { get; set; }

    [JsonIgnore] public virtual ICollection<FeedbackDto>? Feedbacks { get; set; }
}