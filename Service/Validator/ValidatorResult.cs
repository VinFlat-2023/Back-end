namespace Service.Validator;

public class ValidatorResult
{
    public ValidatorResult()
    {
        Failures = new List<string>();
    }

    public bool IsValid => !Failures.Any();

    public List<string> Failures { get; set; }
}