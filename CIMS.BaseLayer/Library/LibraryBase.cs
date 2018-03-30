using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer
{
    public class LibraryBase
    {
        public int LibraryID { get; set; }

        public string LibraryName { get; set; }

        public int FileTypeId { get; set; }

        public int FileType { get; set; }

        public string FilePath { get; set; }

        public string FileExistence { get; set; }
    }
}
