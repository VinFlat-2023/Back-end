namespace Domain.ViewModel.RenterEntity;

public class RenterProfileEntity
{
    public int RenterId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }
    public string? FullName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? ImageUrl { get; set; }
    public string? CitizenNumber { get; set; }
    public string? CitizenImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Gender { get; set; }
    public string? DeviceToken { get; set; }
}