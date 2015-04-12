using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CeProjectManager.Models
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }

        [MaxLength(1024), StringLength(1024, ErrorMessage = "{0} can have max length of {1} characters")]
        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Group DestinationGroup { get; set; }
    }
}
