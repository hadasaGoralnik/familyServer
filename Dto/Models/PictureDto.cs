﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class PictureDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
    }
}
