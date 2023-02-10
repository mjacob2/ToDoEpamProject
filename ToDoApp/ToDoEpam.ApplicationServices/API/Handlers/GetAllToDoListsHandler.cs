using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoEpam.ApplicationServices.API.Domain.Requests;
using ToDoEpam.ApplicationServices.API.Domain.Responses;
using ToDoEpam.DataAccess.CQRS;
using ToDoEpam.DataAccess.CQRS.Queries;

namespace ToDoEpam.ApplicationServices.API.Handlers
{
        internal class GetAllToDoListsHandler : IRequestHandler<GetToDoListsRequest, GetToDoListsResponse>
        {
                private readonly IQueryExecutor queryExecutor;
                public GetAllToDoListsHandler(IQueryExecutor queryExecutor)
                {
                        this.queryExecutor = queryExecutor;
                }
                public async Task<GetToDoListsResponse> Handle(GetToDoListsRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetToDoListsQuery();
                        var toDoListsFromServer = await this.queryExecutor.Execute(query);
                        var ToDoListsMappedToModel = toDoListsFromServer.Select(x => new Domain.Models.ToDoList()
                        {
                                Id = x.Id,
                                Name = x.Name,
                        }).ToList();
                        var response = new GetToDoListsResponse()
                        {
                                ResponseData = ToDoListsMappedToModel,
                        };
                        return response;
                }
        }
}
