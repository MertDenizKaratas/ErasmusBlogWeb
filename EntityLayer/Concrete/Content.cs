using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        [StringLength(100)]
        public string ContentValue { get; set; }
        [StringLength(100)]
        public string ContentDate { get; set; }

        //Navigational Properties
        public int HeaderId { get; set; }
        public virtual Header Header { get; set; }

        public int? WriterId { get; set; }   
        public virtual Writer Writer { get; set; }
    }
}
