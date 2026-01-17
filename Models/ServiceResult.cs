namespace studentMangementSystem.Models
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public static ServiceResult Ok(string message = "Done", object? data = null)
            => new ServiceResult { Success = true, Message = message, Data = data };

        public static ServiceResult Fail(string message = "Error", object? data = null)
            => new ServiceResult { Success = false, Message = message, Data = data };
    }
}
