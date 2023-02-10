using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoEpam.DataAccess.Entities;

namespace ToDoEpam.DataAccess.CQRS.Queries
{
        public class GetToDoItemQuery : QueryBase<ToDoItem>
        {
                public int Id { get; set; }

                public override async Task<ToDoItem> Execute(ToDoAppStorageContext context)
                {
                        var ToDoItem = await context.ToDoItems.FirstOrDefaultAsync(x => x.Id == Id);
                        return ToDoItem;
                }
        }
}
