using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingDomain.DomainModels
{
    public class CarProfileModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public Chatacteristics? Characteristics { get; set; } = default;
        public decimal? PricePerDay { get; set; }

        public List<Image>? Images { get; set; }
    }
}
