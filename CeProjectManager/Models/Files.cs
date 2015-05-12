using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace CeProjectManager.Models
{
    public class Files
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }

        public string Name { get; set; }

        public long Size { get; set; } //in bytes

        public virtual User AddedBy { get; set; }

        public virtual User LastModificationBy { get; set; }

        public DateTime AddDateTime { get; set; }

        public DateTime ModificationDateTime { get; set; }
        
        public string Hash { get; set; }

        public string Path { get; set; }

        [NotMapped]
        public Version Version { get; set; }

        public String VersionString
        {
            get { return Version.ToString(); }
            set { Version = Version.Parse(value); }
        }

        [NotMapped]
        public int SizeKB { get { return (int)(Size / 1024); } }

        [NotMapped]
        public int SizeMB { get { return (int)(Size / 1048576); } }

        [NotMapped]
        public string NameOnDrive { get { return Hash; } }
    }
}