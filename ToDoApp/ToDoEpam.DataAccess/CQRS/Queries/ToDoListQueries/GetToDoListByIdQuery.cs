using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoEpam.DataAccess.Entities;

namespace ToDoEpam.DataAccess.CQRS.Queries.ToDoListQueries
{
        public class GetToDoListByIdQuery : QueryBase<ToDoList>
        {
                public int ToDoListId { get; set; }

                public override async Task<ToDoList> Execute(ToDoAppStorageContext context)
                {
                        var toDoList = await context.ToDoLists
                                .Where(x => x.Id == ToDoListId)
                                .Include("ToDoItems")
                                .FirstOrDefaultAsync();
                        return toDoList;
                }
        }
}
