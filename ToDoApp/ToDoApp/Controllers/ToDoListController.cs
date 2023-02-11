using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoEpam.ApplicationServices.API.Domain.Requests.ToDoListRequests;

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

                [HttpPost]
                [Route("")]
                public async Task<IActionResult> AddToDoList([FromBody] AddToDoListRequest request)
                {
                        var response = await this.mediator.Send(request);
                        return this.Ok(response);
                }


        }
}
