using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        [StringLength(100)]
        public string WriterUsername { get; set; }
        [StringLength(100)]
        public string WriterName { get; set; }
        [StringLength(100)]
        public string WriterSurname { get; set; }
        [StringLength(250)]
        public string WriterImage { get; set; }
        [StringLength(100)]
        public string WriterMail { get; set; }
        [StringLength(100)]
        public string WritePassword { get; set; }



        //Navigational Properties
     
        public virtual ICollection<Header> Headers { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
    }
}
