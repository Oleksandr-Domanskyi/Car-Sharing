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
        public CarChatacteristics Characteristics { get; set; } = default!;
        public decimal? PricePerDay { get; set; }

        public List<Image> Image { get; set; } = default!;
    }
}
