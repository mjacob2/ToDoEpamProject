using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoEpam.ApplicationServices.API.Domain.Responses
{
        public class ResponseBase<T> : ErrorResponseBase
        {
                public T ResponseData { get; set; }
        }
}
