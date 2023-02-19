using System.Threading.Tasks;
using ToDoEpam.DataAccess.Entities;

namespace ToDoEpam.DataAccess.CQRS.Commands.TodoListCommands
{
        /// <summary>
        /// Command to add new <see cref="ToDoList"/> to the database.
        /// </summary>
        public class AddToDoListCommand : CommandBase<ToDoList, ToDoList>
        {
                public override async Task<ToDoList> Execute(ToDoAppStorageContext context)
                {                        
                        await context.ToDoLists.AddAsync(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}
