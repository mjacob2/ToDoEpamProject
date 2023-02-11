using MediatR;
using ToDoEpam.ApplicationServices.API.Domain.Responses;

namespace ToDoEpam.ApplicationServices.API.Domain.Requests
{
        public class GetAllToDoListsRequest : IRequest<GetAllToDoListsResponse>
        {
        }
}
