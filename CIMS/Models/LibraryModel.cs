using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIMS.Models
{
    public class LibraryModel
    {
        public int LibraryID { get; set; }
        [Required]
        public string LibraryName { get; set; }
        [Required]
        public int FileTypeId { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public string FileExistence { get; set; }

        public string FileType { get; set; }

        public List<LibraryModel> LibraryList = new List<LibraryModel>();
    }
}