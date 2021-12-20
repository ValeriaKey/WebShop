using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Files
{
    public class ExistingFilePathForCarViewModel
    {
        public Guid PhotoId { get; set; }
        public string FilePath { get; set; }
        public Guid CarId { get; set; }
    }
}
