using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoEpam.DataAccess.Entities
{
        internal class ToDo : EntityBase
        {
                [Required]
                [MaxLength(50)]
                public string Title { get; set; } = string.Empty;

                [MaxLength(350)]
                public string Description { get; set; } = string.Empty;

                public DateTime Deadline { get; set; }

                public DateTime ReminderDate { get; set; }

                [Required]
                public bool IsFavorite { get; set; } = false;

                [Required]
                public bool IsCompleted { get; set; } = false;

                //public List<Attachment> Attachments { get; set; } = new List<Attachment>();

                [Required]
                public int ToDoListId { get; set; }

                public ToDoList? ToDoList { get; set; }

                

        }
}
