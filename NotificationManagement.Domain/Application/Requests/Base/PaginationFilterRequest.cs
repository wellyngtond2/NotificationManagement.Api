namespace NotificationManagement.Domain.Application.Requests.Base
{
    public class PaginationFilterRequest
    {
        public int? RecordsPerPage { get; set; }
        public int? PageNumber { get; set; }
    }
}
