using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoEpam.ApplicationServices.API.Domain.Requests.ToDoListRequests;
using ToDoEpam.ApplicationServices.API.Domain.Responses.ToDoListResponses;
using ToDoEpam.DataAccess.CQRS;
using ToDoEpam.DataAccess.CQRS.Queries.ToDoListQueries;

namespace ToDoEpam.ApplicationServices.API.Handlers.ToDoListHandlers
{
        public class GetToDoListByIdHandler : IRequestHandler<GetToDoListByIdRequest, GetToDoListByIdResponse>
        {
                private readonly IQueryExecutor queryExecutor;

                public GetToDoListByIdHandler(IQueryExecutor queryExecutor)
                {
                        this.queryExecutor = queryExecutor;
                }

                public async Task<GetToDoListByIdResponse> Handle(GetToDoListByIdRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetToDoListByIdQuery()
                        {
                                ToDoListId = request.ToDoListId,
                        };
                        var toDoListFromDb = await this.queryExecutor.Execute(query);
                        var toDoListMappedToModel = new Domain.Models.ToDoListByIdModel()
                        {
                                Id = toDoListFromDb.Id,
                                Name = toDoListFromDb.Name,
                                CreationDate = toDoListFromDb.CreationDate,
                                ToDoItems = toDoListFromDb.ToDoItems,
                        };
                        var response = new GetToDoListByIdResponse()
                        {
                                ResponseData = toDoListMappedToModel,
                        };
                        return response;
                }
        }
}
