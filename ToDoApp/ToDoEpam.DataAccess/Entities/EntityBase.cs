using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoEpam.DataAccess.Entities
{
        internal class EntityBase
        {
                [Key]
                public int Id {get; set;}

                public DateTime CreationDate {get; private set;} = DateTime.Now;
        }
}
