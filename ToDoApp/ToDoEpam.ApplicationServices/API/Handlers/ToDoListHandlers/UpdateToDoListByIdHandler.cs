using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoEpam.ApplicationServices.API.Domain.Requests.ToDoListRequests;
using ToDoEpam.ApplicationServices.API.Domain.Responses.ToDoListResponses;
using ToDoEpam.DataAccess.CQRS.Commands.TodoListCommands;
using ToDoEpam.DataAccess.CQRS;
using ToDoEpam.DataAccess.Entities;

namespace ToDoEpam.ApplicationServices.API.Handlers.ToDoListHandlers
{
        public class UpdateToDoListByIdHandler : IRequestHandler<UpdateToDoListByIdRequest, UpdateToDoListByIdResponse>
        {
                private readonly ICommandExecutor commandExecutor;

                public UpdateToDoListByIdHandler(ICommandExecutor commandExecutor)
                {
                        this.commandExecutor = commandExecutor;
                }

                public async Task<UpdateToDoListByIdResponse> Handle(UpdateToDoListByIdRequest request, CancellationToken cancellationToken)
                {
                        var ToDoListMappedToEntity = new ToDoList()
                        {
                                Id= request.Id,
                                Name = request.Name,
                        };
                        var command = new UpdateToDoListCommand() { Parameter = ToDoListMappedToEntity };
                        var updatedToDoListFromDb = await this.commandExecutor.Execute(command);
                        return new UpdateToDoListByIdResponse()
                        {
                                ResponseData = new Domain.Models.ToDoListGeneralModel()
                                {
                                        Id = updatedToDoListFromDb.Id,
                                        Name = updatedToDoListFromDb.Name,
                                }
                        };
                }
        }
}