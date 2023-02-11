namespace Core.Utilities.Results;

public class Result : IResult
{
    // "this" bu class anlamına gelir
    // Aşağıdaki gibi bir constructoru diğreine inherit ederek iki constructorun aynı anda çalışmasını sağladık.
    // Böylelikle "message" nesnesinin kullanılmasını isteğe bağlı bıraktık
    public Result(bool success, string message):this(success)
    {
        Message = message;
    }
    public Result(bool success)
    {
        Success = success;
    }

    public bool Success { get; }
    public string Message { get; }
}