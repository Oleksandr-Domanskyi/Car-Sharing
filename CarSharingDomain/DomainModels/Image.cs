﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingDomain.DomainModels
{
    public class Image
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? TypeFile { get; set; }
        public byte[]? Data { get; set; }

        public virtual CarProfileModel? CarProfileModel { get; set; }

    }
}
