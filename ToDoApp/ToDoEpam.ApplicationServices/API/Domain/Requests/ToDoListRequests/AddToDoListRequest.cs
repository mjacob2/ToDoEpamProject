using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoEpam.ApplicationServices.API.Domain.Responses.ToDoListResponses;

namespace ToDoEpam.ApplicationServices.API.Domain.Requests.ToDoListRequests
{
        public class AddToDoListRequest : IRequest<AddToDoListResponse>
        {
                public string Name { get; set; }
        }
}
