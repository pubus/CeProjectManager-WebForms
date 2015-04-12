using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CeProjectManager.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        
        public virtual User Sender { get; set; }

        public virtual User Recipient { get; set; }

        public DateTime DateTime { get; set; }

        [MaxLength(1024), StringLength(1024, ErrorMessage = "{0} can have max length of {1} characters")]
        public string Text { get; set; }
    }
}