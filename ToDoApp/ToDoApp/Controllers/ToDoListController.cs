using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoEpam.ApplicationServices.API.Domain.Requests;

namespace ToDoApp.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class ToDoListController : ControllerBase
        {
                private readonly IMediator mediator;

                public ToDoListController(IMediator mediator)
                {
                        this.mediator = mediator;
                }

                [HttpGet]
                [Route("")]
                public async Task<IActionResult> GetAllToDoLists([FromQuery] GetAllToDoListsRequest request)
                {
                        var response = await this.mediator.Send(request);
                        return this.Ok(response);
                }


        }
}
