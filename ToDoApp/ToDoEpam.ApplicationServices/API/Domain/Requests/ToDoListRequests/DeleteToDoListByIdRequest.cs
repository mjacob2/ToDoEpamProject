using MediatR;
using ToDoEpam.ApplicationServices.API.Domain.Responses.ToDoListResponses;

namespace ToDoEpam.ApplicationServices.API.Domain.Requests.ToDoListRequests
{
        public class DeleteToDoListByIdRequest :  IRequest<DeleteToDoListByIdResponse>
        {
                public int ToDoListId { get; set; }
        }
}
