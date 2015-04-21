using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CeProjectManager.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        
        public virtual User Sender { get; set; }

        public virtual User Recipient { get; set; }

        [MaxLength(255), StringLength(255, ErrorMessage = "{0} can have max length of {1} characters")]
        public string Subject { get; set; }

        [MaxLength(1024), StringLength(1024, ErrorMessage = "{0} can have max length of {1} characters")]
        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public bool Unread { get; set; }

        [NotMapped]
        public string ShortText
        {
            get
            {
                if (Text != null && Text.Length > 45)
                {
                    return Text.Substring(0, 45) + "...";
                }
                else
                {
                    return Text;
                }
            }
        }
    }
}