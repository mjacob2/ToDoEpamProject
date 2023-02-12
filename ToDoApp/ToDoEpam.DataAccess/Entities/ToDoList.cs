using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoEpam.DataAccess.Entities
{
        public class ToDoList : EntityBase
        {
                [Required]
                [MaxLength(50)]
                public string Name { get; set; }

                public virtual List<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
        }
}
