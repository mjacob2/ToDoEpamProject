using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoEpam.DataAccess.CQRS.Queries;

namespace ToDoEpam.DataAccess.CQRS
{
        public interface IQueryExecutor
        {
                Task<TResoult> Execute<TResoult>(QueryBase<TResoult> query);
        }
}
