using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoEpam.DataAccess.CQRS.Commands;

namespace ToDoEpam.DataAccess.CQRS
{
        public interface ICommandExecutor
        {
                Task<TResoult> Execute<TParameters, TResoult>(CommandBase<TParameters, TResoult> command);
        }
}
