using System.Threading.Tasks;
using ToDoEpam.DataAccess.Entities;

namespace ToDoEpam.DataAccess.CQRS.Commands.TodoListCommands
{
        /// <summary>
        /// Command to remove <see cref="ToDoList"/> from the database.
        /// </summary>
        public class DeleteToDoListByIdCommand : CommandBase<ToDoList, ToDoList>
        {
                public override async Task<ToDoList> Execute(ToDoAppStorageContext context)
                {
                        context.ToDoLists.Remove(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}
