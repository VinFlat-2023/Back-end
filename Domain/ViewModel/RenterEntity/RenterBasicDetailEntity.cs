namespace Domain.ViewModel.RenterEntity;

public class RenterBasicDetailEntity
{
    public int RenterId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string FullName { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool Status { get; set; }
}