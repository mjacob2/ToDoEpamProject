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
                public string Name { get; set; } = string.Empty;

                public virtual List<ToDoItem> Tasks { get; set; } = new List<ToDoItem>();
        }
}
