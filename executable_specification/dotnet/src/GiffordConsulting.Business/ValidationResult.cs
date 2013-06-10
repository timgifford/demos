public class ValidationResult
{
    private string errorMessage = string.Empty;
   
    public override string ToString()
    {
        return errorMessage;
    }

    public void Add(string message)
    {
        errorMessage = message;
    }

    public bool IsValid()
    {
        return (errorMessage.Length == 0);
    }

}