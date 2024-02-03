using CarSharingDomain.DomainModels.Enums;
using CarSharingDomain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.DataTransferObjects
{
    public class EditCarSharingProfileModelObject
    {
        //Car Profile
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public CarChatacteristics? Characteristics { get; set; } = default;
        public decimal PricePerDay { get; set; }
        public List<Image> Images { get; set; } = default!;

        //Contact Details
        public string? Coutry { get; set; }
        public string? City { get; set; }
        public string? ContactNumber { get; set; }
        public ValueMoney? ValueMoney { get; set; }

    }
}
