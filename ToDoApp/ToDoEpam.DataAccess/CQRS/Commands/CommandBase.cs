using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoEpam.DataAccess.CQRS.Commands
{       
        /// <summary>
        /// Base for commands
        /// </summary>
        /// <typeparam name="TParameter"> Data to modify the database </typeparam>
        /// <typeparam name="TResoult"> Resoult data of the command </typeparam>
        public abstract class CommandBase<TParameter, TResoult>
        {
                public TParameter Parameter { get; set; }

                /// <summary>
                /// Executes command
                /// </summary>
                /// <param name="context"> Context of data access </param>
                /// <returns></returns>
                public abstract Task<TResoult> Execute(ToDoAppStorageContext context);

        }
}
