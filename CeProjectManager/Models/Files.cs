using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace CeProjectManager.Models
{
    public class Files
    {
        public string Name { get; set; }

        public long Size { get; set; } //in bytes
        
        public DateTime LastModified { get; set; }
        
        public string Hash { get; set; }

        public string Path { get; set; }

        public Version Version { get; set; }

        [NotMapped]
        public int SizeKB { get { return (int)(Size / 1024); } }

        [NotMapped]
        public int SizeMB { get { return (int)(Size / 1048576); } }

        [NotMapped]
        public string NameOnDrive { get { return Hash; } }
        
    }
}