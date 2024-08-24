namespace Identity.Core;

// Used for both development and production mode. Details prop will only be present on development mode.
public class AppException
{
    public AppException(int statusCode, string message, string? detais = null)
    {
        StatusCode = statusCode;
        Message = message;
        Detais = detais;
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string? Detais { get; set; }
}