using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoEpam.DataAccess.CQRS.Queries
{
        public abstract class QueryBase<TResoult>
        {
                public abstract Task<TResoult> Execute(ToDoAppStorageContext context);
        }
}
