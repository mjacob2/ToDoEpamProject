using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ToDoApp.Controllers
{
        public class ApiControllerBase : ControllerBase
        {
                protected readonly IMediator mediator;
                public ApiControllerBase(IMediator mediator)
                {
                        this.mediator = mediator;
                }

                protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
                {
                        var response = await this.mediator.Send(request);
                        return this.Ok(response);
                }
        }
}
