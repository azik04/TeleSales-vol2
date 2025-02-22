namespace TeleSales.Core.Response;

public class FileResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public byte[] ErrorFileBytes { get; set; }

    public FileResponse(T data, bool success = true, string message = null, byte[] errorFileBytes = null)
    {
        Success = success;
        Message = message;
        Data = data;
        ErrorFileBytes = errorFileBytes;

    }

    public FileResponse(string message, byte[] errorFileBytes = null)
    {
        Success = false;
        Message = message;
        ErrorFileBytes = errorFileBytes;
    }
}
