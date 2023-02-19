using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoEpam.DataAccess.Entities;

namespace ToDoEpam.DataAccess.CQRS.Queries.ToDoListQueries
{
        public class GetAllToDoListsQuery : QueryBase<List<ToDoList>>
        {
                public string? Name { get; set; }

                public override Task<List<ToDoList>> Execute(ToDoAppStorageContext context)
                {
                        if (this.Name != null)
                        {
                                return context.ToDoLists
                                        .Where(x => x.Name
                                        .Contains(this.Name))
                                        .ToListAsync();
                        }
                        else
                        {
                                return context.ToDoLists.ToListAsync();
                        }
                }
        }
}
