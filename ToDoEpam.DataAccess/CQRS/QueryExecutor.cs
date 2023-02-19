using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoEpam.DataAccess.CQRS.Queries;

namespace ToDoEpam.DataAccess.CQRS
{
        public class QueryExecutor : IQueryExecutor
        {
                private readonly ToDoAppStorageContext context;

                public QueryExecutor(ToDoAppStorageContext context)
                {
                        this.context = context;
                }

                public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
                {
                        return query.Execute(this.context);
                }
        }
}
