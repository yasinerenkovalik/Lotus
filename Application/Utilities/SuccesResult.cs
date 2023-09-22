namespace Application.Utilities;

public class SuccesResult:Result
{
    public SuccesResult( string message) : base(true, message)
    {
    }

    public SuccesResult() : base(true)
    {
    }
}