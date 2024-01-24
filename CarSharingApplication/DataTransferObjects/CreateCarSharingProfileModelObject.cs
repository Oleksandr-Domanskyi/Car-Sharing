using CarSharingDomain.DomainModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.DataTransferObjects
{
    public class CreateCarSharingProfileModelObject
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public CarChatacteristics? Characteristics { get; set; } = default;
        public decimal? PricePerDay { get; set; }
        public string? Silnik { get; set; }
        public string? Color { get; set; }
        public string? Felgi { get; set; }
        public string? Tapicerka { get; set; }
        public List<IFormFile> Images { get; set; } = default!;

    }

}
