using MediatR;
using ToDoEpam.ApplicationServices.API.Domain.Responses.ToDoListResponses;

namespace ToDoEpam.ApplicationServices.API.Domain.Requests.ToDoListRequests
{
    public class GetAllToDoListsRequest : IRequest<GetAllToDoListsResponse>
    {
                public string Name { get; set; }
    }
}
