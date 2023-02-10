using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoEpam.DataAccess.Entities
{
        public class Attachment : EntityBase
        {
                public byte[]? File { get; set; }

                [Required]
                public int ToDoId { get; set; }

                public ToDo? ToDo { get; set; }
        }
}
