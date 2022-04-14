using AutoMapper;
using MediatR;
using NotificationManagement.Domain.Application.Requests.Person;
using NotificationManagement.Domain.Application.Responses.Base;
using NotificationManagement.Domain.Application.Responses.Person;
using NotificationManagement.Domain.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationManagement.Domain.Domain.Handlers.Person
{
    public class GetPersonHandler : IRequestHandler<GetPersonRequest, OperationResponse<ICollection<PersonResponse>>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public GetPersonHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<OperationResponse<ICollection<PersonResponse>>> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            var persons = await _personRepository.GetAllAsync(request.Filter.RecordsPerPage, request.Filter.PageNumber);

            var response = _mapper.Map<ICollection<PersonResponse>>(persons);

            return OperationResponse.SuccessPaged(response, (request.Filter.PageNumber ?? 1));
        }
    }
}