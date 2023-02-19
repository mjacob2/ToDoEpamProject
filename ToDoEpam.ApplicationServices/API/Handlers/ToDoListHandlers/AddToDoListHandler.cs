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
using ToDoEpam.DataAccess.CQRS.Commands.TodoListCommands;
using ToDoEpam.DataAccess.Entities;

namespace ToDoEpam.ApplicationServices.API.Handlers.ToDoListHandlers
{
        public class AddToDoListHandler : IRequestHandler<AddToDoListRequest, AddToDoListResponse>
        {
                private readonly ICommandExecutor commandExecutor;

                public AddToDoListHandler(ICommandExecutor commandExecutor)
                {
                        this.commandExecutor = commandExecutor;
                }

                public async Task<AddToDoListResponse> Handle(AddToDoListRequest request, CancellationToken cancellationToken)
                {
                        var ToDoListMappedToEntity = new ToDoList()
                        {
                                Name = request.Name,
                                CreationDate = DateTime.Now,
                        };
                        var command = new AddToDoListCommand(){ Parameter = ToDoListMappedToEntity };
                        var toDoListFromDb = await this.commandExecutor.Execute(command);
                        return new AddToDoListResponse()
                        {
                                ResponseData = new Domain.Models.ToDoListGeneralModel()
                                {
                                        Id = toDoListFromDb.Id,
                                        Name = toDoListFromDb.Name,
                                }
                        };
                }
        }
}
