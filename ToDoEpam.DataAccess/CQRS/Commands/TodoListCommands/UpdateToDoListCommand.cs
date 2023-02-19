using System.Threading.Tasks;
using ToDoEpam.DataAccess.Entities;

namespace ToDoEpam.DataAccess.CQRS.Commands.TodoListCommands
{
        public class UpdateToDoListCommand : CommandBase<ToDoList, ToDoList>
        {
                public override async Task<ToDoList> Execute(ToDoAppStorageContext context)
                {
                        context.ToDoLists.Update(this.Parameter);
                        context.Entry(this.Parameter)
                                .Property(x => x.CreationDate).IsModified = false;
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}
