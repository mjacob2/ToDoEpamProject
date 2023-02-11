﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDoEpam.DataAccess.Entities
{
        public class ToDoItem : EntityBase
        {
                [Required]
                [MaxLength(50)]
                public string Title { get; set; } = string.Empty;

                [MaxLength(350)]
                public string Description { get; set; } = string.Empty;

                public DateTime? Deadline { get; set; }

                public DateTime ReminderDate { get; set; }

                [Required]
                public bool IsFavorite { get; set; } = false;

                [Required]
                public bool IsCompleted { get; set; } = false;

                //public List<Attachment> Attachments { get; set; } = new List<Attachment>();

                public int ToDoListId { get; set; }

                [JsonIgnore]
                public virtual ToDoList ToDoList { get; set; }
        }
}
