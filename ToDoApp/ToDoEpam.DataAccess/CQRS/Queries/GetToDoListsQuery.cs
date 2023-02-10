using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoEpam.DataAccess.Entities;

namespace ToDoEpam.DataAccess.CQRS.Queries
{
        public class GetToDoListsQuery : QueryBase<List<ToDoList>>
        {
                public override Task<List<ToDoList>> Execute(ToDoAppStorageContext context)
                {
                        return context.ToDoLists.ToListAsync();
                        
                }
        }
}
