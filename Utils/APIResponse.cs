namespace BackOffice.Utils
{
    public class ApiResponse<T>
    {
        public required int Status { get; set; } = 200;
        public required string Message { get; set; }
        public T? Data { get; set; }

        public static ApiResponse<T> Ok(T data, string? message = null)
        {
            return new ApiResponse<T>
            {
                Status = 200,
                Message = message ?? "Success",
                Data = data,
            };
        }

        public static ApiResponse<T> Fail(string message)
        {
            return new ApiResponse<T>
            {
                Status = 0,
                Message = message,
                Data = default,
            };
        }
    }
}
