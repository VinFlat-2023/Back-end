namespace Domain.ViewModel.RenterEntity;

public class RenterDetailEntity
{
    public int RenterId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? FullName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? CitizenNumber { get; set; }
    public string? CitizenImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Gender { get; set; }
}