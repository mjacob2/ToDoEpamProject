using MediatR;
using ToDoEpam.ApplicationServices.API.Domain.Responses;

namespace ToDoEpam.ApplicationServices.API.Domain.Requests
{
        internal class GetToDoListsRequest : IRequest<GetToDoListsResponse>
        {
        }
}
