namespace NotificationManagement.Domain.Application.Responses.Base
{
    public class OperationResponse
    {
        public string Message { get; }
        public bool IsSuccess { get; }

        public OperationResponse()
        {

        }
        protected OperationResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        protected OperationResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
            Message = string.Empty;
        }
        public static OperationResponse Success() => new(true);
        public static OperationResponse<T> Success<T>(T data) => new(data, true);
        public static OperationResponse<T> SuccessPaged<T>(T data, int? pageNumber) => new(data, true, pageNumber);
        public static OperationResponse Success(string message) => new(true, message);
        public static OperationResponse Error(string message) => new(false, message);
    }

    public class OperationResponse<T> : OperationResponse
    {
        public T Data { get; set; }
        public int? PageNumber { get; }
        public int? TotalRegisters { get; }
        public OperationResponse()
        {
        }

        internal OperationResponse(T data, bool isSuccess, int? pageNumber = null, int? totalRegisters = null) : base(isSuccess)
        {
            Data = data;
            PageNumber = pageNumber;
            TotalRegisters = totalRegisters;
        }
    }
}
