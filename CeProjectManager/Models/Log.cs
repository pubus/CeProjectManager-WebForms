using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CeProjectManager.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }

        public DateTime DateTime { get; set; }

        [MaxLength(2048)]
        public string Text { get; set; }
    }
}