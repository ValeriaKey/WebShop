﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Dtos
{
    public class ExistingFilePathDto
    {
        public Guid? PhotoId { get; set; }
        public string FilePath { get; set; }
        public Guid? ProductId { get; set; }
    }
}
