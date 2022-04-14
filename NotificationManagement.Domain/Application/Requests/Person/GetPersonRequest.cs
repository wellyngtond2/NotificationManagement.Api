using MediatR;
using NotificationManagement.Domain.Application.Requests.Base;
using NotificationManagement.Domain.Application.Responses.Base;
using NotificationManagement.Domain.Application.Responses.Person;
using System.Collections.Generic;

namespace NotificationManagement.Domain.Application.Requests.Person
{
    public class GetPersonRequest : IRequest<OperationResponse<ICollection<PersonResponse>>>
    {
        public PaginationFilterRequest Filter { get; }
        public GetPersonRequest(PaginationFilterRequest filter)
        {
            Filter = filter;
        }
    }
}
