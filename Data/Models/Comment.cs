using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface.Models
{
    public class Comment : BaseModel
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public virtual Image Image { get; set; }
    }
}
