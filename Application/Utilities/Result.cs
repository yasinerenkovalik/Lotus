namespace Application.Utilities;

public class Result:IResult
{
    public Result(bool success,string message):this(success)
    {
        Message = message;
        Success = success;
    }
    public Result(bool success)
    {
        Success = success;
    }
    public bool Success { get; }
    public string Message { get; }
}