namespace Domain.DTOs.Output;

public class Result<T>
{
    public class ErrorType
    {
        public required string ErrorMessage { get; set; }
    }

    public bool IsSuccess { get; set; }
    public T? Value { get; set; }
    public ErrorType? Error { get; set; }

    public static Result<T> Success(T? value) => new Result<T> { IsSuccess = true, Value = value };
    public static Result<T> Failure(string error) => new Result<T> { IsSuccess = false, Error = new ErrorType { ErrorMessage = error } };
}
