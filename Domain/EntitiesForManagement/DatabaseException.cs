using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class DatabaseException
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ExceptionId { get; set; }

    public Guid Guid { get; set; }
    public string? ApplicationName { get; set; }
    public string? MachineName { get; set; }
    public DateTime? CreationDate { get; set; }
    public string? Type { get; set; }
    public bool? IsProtected { get; set; }
    public string? Host { get; set; }
    public string? Url { get; set; }
    public string? HttpMethod { get; set; }
    public string? Ipaddress { get; set; }
    public string? Source { get; set; }
    public string? Message { get; set; }
    public string? Detail { get; set; }
    public int? StatusCode { get; set; }
    public DateTime? DeletionDate { get; set; }
    public string? FullJson { get; set; }
    public int? ErrorHash { get; set; }
    public int DuplicateCount { get; set; }
    public DateTime? LastLogDate { get; set; }
    public string? Category { get; set; }
}