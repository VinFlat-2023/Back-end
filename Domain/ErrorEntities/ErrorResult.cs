namespace Domain.ErrorEntities;

public class ErrorResult
{
    public bool Success { get; set; } = true;
    public string Msg { get; set; } = "";
    public string Type { get; set; } = "";
    public object Data { get; set; } = "";
    public object DataExt { get; set; } = "";
}