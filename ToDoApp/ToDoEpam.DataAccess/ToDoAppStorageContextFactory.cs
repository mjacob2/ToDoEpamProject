using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoEpam.DataAccess
{
        public class ToDoAppStorageContextFactory : IDesignTimeDbContextFactory<ToDoAppStorageContext>
        {
                public ToDoAppStorageContext CreateDbContext(string[] args)
                {
                        var optionsBuilder = new DbContextOptionsBuilder<ToDoAppStorageContext>();
                        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ToDoAppEpam;Trusted_Connection=True;");
                        return new ToDoAppStorageContext(optionsBuilder.Options);
                }
        }
}