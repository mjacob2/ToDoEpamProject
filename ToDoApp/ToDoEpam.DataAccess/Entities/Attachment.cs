using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoEpam.DataAccess.Entities
{
        internal class Attachment : EntityBase
        {
                public byte[]? File { get; set; }
        }
}
