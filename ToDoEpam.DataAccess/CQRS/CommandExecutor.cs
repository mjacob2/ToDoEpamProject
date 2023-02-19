using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoEpam.DataAccess.CQRS.Commands;

namespace ToDoEpam.DataAccess.CQRS
{
        public class CommandExecutor : ICommandExecutor
        {
                private readonly ToDoAppStorageContext context;

                public CommandExecutor(ToDoAppStorageContext context)
                {
                        this.context = context;
                }

                public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
                {
                        return command.Execute(this.context);
                }
        }
}