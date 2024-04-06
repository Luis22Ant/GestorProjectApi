namespace Gestor.Communication.Response;

public class ResponseException
{
    public  string Message { get; set; } = string.Empty;

    public ResponseException(string message)
    {
        Message = message;
    }
}
