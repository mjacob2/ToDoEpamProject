using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoEpam.ApplicationServices.API.Domain.Requests.ToDoListRequests;
using ToDoEpam.ApplicationServices.API.Domain.Responses.ToDoListResponses;

namespace ToDoApp.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class ToDoListController : ApiControllerBase
        {
                public ToDoListController(IMediator mediator) : base(mediator)
                {
                }

                [HttpGet]
                [Route("")]
                public Task<IActionResult> GetAllToDoLists([FromQuery] GetAllToDoListsRequest request)
                {
                        return this.HandleRequest<GetAllToDoListsRequest, GetAllToDoListsResponse>(request);
                }

                [HttpPost]
                [Route("")]
                public Task<IActionResult> AddToDoList([FromBody] AddToDoListRequest request)
                {
                        return this.HandleRequest<AddToDoListRequest, AddToDoListResponse>(request);
                }

                [HttpGet]
                [Route("{toDoListId}")]
                public Task<IActionResult> GetToDoListById([FromRoute] int toDoListId)
                {
                        var request = new GetToDoListByIdRequest()
                        {
                                ToDoListId = toDoListId,
                        };
                        return this.HandleRequest<GetToDoListByIdRequest, GetToDoListByIdResponse>(request);
                }

                [HttpDelete]
                [Route("{toDoListId}")]
                public Task<IActionResult> DeleteToDoListById([FromRoute] int toDoListId)
                {
                        var request = new DeleteToDoListByIdRequest()
                        {
                                ToDoListId = toDoListId
                        };

                        return this.HandleRequest<DeleteToDoListByIdRequest, DeleteToDoListByIdResponse>(request);
                }


                [HttpPut]
                [Route("{toDoListId}")]
                public Task<IActionResult> UpdateToDoListById([FromRoute] int toDoListId, [FromBody] UpdateToDoListByIdRequest request)
                {
                        request.Id = toDoListId;

                        return this.HandleRequest<UpdateToDoListByIdRequest, UpdateToDoListByIdResponse>(request);
                }


        }
}
