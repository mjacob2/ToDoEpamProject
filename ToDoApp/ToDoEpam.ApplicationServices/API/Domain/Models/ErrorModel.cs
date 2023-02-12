using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoEpam.ApplicationServices.API.Domain.Models
{
    public class ErrorModel
    {
        public ErrorModel(string error)
        {
            Error = error;
        }

        public string Error { get; }
    }
}
