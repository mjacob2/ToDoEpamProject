using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoEpam.ApplicationServices.API.Domain.Requests;
using ToDoEpam.ApplicationServices.API.Domain.Responses;
using ToDoEpam.DataAccess.CQRS;
using ToDoEpam.DataAccess.CQRS.Queries;

namespace ToDoEpam.ApplicationServices.API.Handlers
{
        internal class GetAllToDoListsHandler : IRequestHandler<GetAllToDoListsRequest, GetAllToDoListsResponse>
        {
                private readonly IQueryExecutor queryExecutor;
                public GetAllToDoListsHandler(IQueryExecutor queryExecutor)
                {
                        this.queryExecutor = queryExecutor;
                }
                public async Task<GetAllToDoListsResponse> Handle(GetAllToDoListsRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetAllToDoListsQuery();
                        var toDoListsFromServer = await this.queryExecutor.Execute(query);
                        var ToDoListsMappedToModel = toDoListsFromServer.Select(x => new Domain.Models.ToDoList()
                        {
                                Id = x.Id,
                                Name = x.Name,
                        }).ToList();
                        var response = new GetAllToDoListsResponse()
                        {
                                ResponseData = ToDoListsMappedToModel,
                        };
                        return response;
                }
        }
}
