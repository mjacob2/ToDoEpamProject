using System;
using System.Collections.Generic;
using ToDoEpam.DataAccess.Entities;

namespace ToDoEpam.ApplicationServices.API.Domain.Models
{
        public class ToDoListDetailedModel
        {
                public int Id { get; set; }

                public DateTime CreationDate { get; set; }

                public string Name { get; set; }

                public List<ToDoItem> ToDoItems { get; set; }
        }
}
