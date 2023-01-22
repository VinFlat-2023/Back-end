using System.Runtime.Serialization;

namespace Domain.ErrorEntities;

[DataContract(Name = "ErrorResponse")]
public class ErrorResponse
{
    public ErrorResponse(string message)
    {
        Message = message;
    }

    [DataMember(Name = "Message")] public string Message { get; set; }
}