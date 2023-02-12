using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoEpam.ApplicationServices.API.Domain.Requests.ToDoListRequests;

namespace ToDoEpam.ApplicationServices.API.Validators
{
        public class AddToDoListRequestValidator : AbstractValidator<AddToDoListRequest>
        {
                public AddToDoListRequestValidator()
                {
                        this.RuleFor(x => x.Name).NotEmpty().Length(0,50);
                }
        }
}
