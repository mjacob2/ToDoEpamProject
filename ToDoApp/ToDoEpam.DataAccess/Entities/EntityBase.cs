using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoEpam.DataAccess.Entities
{
        internal class EntityBase
        {
                [Key]
                int Id {get; set;}

                DateTime CreationDate {get; } = DateTime.Now;
        }
}
