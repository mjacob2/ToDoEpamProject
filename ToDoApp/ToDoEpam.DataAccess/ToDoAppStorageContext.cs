using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoEpam.DataAccess.Entities;

namespace ToDoEpam.DataAccess
{
        public class ToDoAppStorageContext : DbContext
        {
                public DbSet<ToDo> ToDos { get; set; }

                public DbSet<ToDoList> ToDoLists { get; set; } 

                public DbSet<Attachment> Attachments { get; set; }

                public ToDoAppStorageContext(DbContextOptions<ToDoAppStorageContext> options) : base(options) { }

        }
}
