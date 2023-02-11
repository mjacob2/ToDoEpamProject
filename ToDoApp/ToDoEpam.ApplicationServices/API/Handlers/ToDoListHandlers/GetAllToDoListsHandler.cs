using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoEpam.ApplicationServices.API.Domain.Requests.ToDoListRequests;
using ToDoEpam.ApplicationServices.API.Domain.Responses.ToDoListResponses;
using ToDoEpam.DataAccess.CQRS;
using ToDoEpam.DataAccess.CQRS.Queries.ToDoListQueries;

namespace ToDoEpam.ApplicationServices.API.Handlers.ToDoListHandlers
{
    public class GetAllToDoListsHandler : IRequestHandler<GetAllToDoListsRequest, GetAllToDoListsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        public GetAllToDoListsHandler(IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllToDoListsResponse> Handle(GetAllToDoListsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllToDoListsQuery()
            {
                    Name = request.Name,
            };
            var toDoListsFromDb = await queryExecutor.Execute(query);
            var ToDoListsMappedToModel = toDoListsFromDb.Select(x => new Domain.Models.ToDoListsModel()
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
