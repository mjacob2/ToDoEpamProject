using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoEpam.DataAccess.Entities;

namespace ToDoEpam.ApplicationServices.API.Domain.Models
{
        public class ToDoListByIdModel
        {
                public int Id { get; set; }
                public DateTime CreationDate { get; set; }

                public string Name { get; set; }

                public List<ToDoItem> ToDoItems { get; set; }
        }
}
