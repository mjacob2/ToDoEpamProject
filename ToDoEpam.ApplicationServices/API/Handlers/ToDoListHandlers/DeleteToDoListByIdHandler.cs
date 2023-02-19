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
        public class DeleteToDoListByIdHandler : IRequestHandler<DeleteToDoListByIdRequest, DeleteToDoListByIdResponse>
        {
                private readonly ICommandExecutor commandExecutor;

                public DeleteToDoListByIdHandler(ICommandExecutor commandExecutor)
                {
                        this.commandExecutor = commandExecutor;
                }

                public async Task<DeleteToDoListByIdResponse> Handle(DeleteToDoListByIdRequest request, CancellationToken cancellationToken)
                {
                        var ToDoListMappedToEntity = new ToDoList()
                        {
                                Id = request.ToDoListId,
                        };
                        var command = new DeleteToDoListByIdCommand() { Parameter = ToDoListMappedToEntity };
                        await this.commandExecutor.Execute(command);
                        return new DeleteToDoListByIdResponse();
                }
        }
}