using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [StringLength(100)]
        public string SenderMail { get; set; }
        [StringLength(100)]
        public string ReceiverMail { get; set; }
        [StringLength(100)]
        public string MessageContent { get; set; }
        [StringLength(100)]
        public string MessageDate { get; set; }
        [StringLength(100)]
        public string MessageSubject { get; set; }
    }
}
