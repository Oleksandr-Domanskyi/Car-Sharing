using AutoMapper;
using CarSharingApplication.DataTransferObjects;
using CarSharingDomain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.Mapping
{
    public class CarSharingMappingProfile:Profile
    {
        public CarSharingMappingProfile()
        {
            CreateMap<CarProfileModel, CarSharingProfileModelObject>()
                .ForMember(dto => dto.Silnik, opt => opt.MapFrom(src => src.Characteristics.Silnik))
                .ForMember(dto => dto.Tapicerka, opt => opt.MapFrom(src => src.Characteristics.Tapicerka))
                .ForMember(dto => dto.Felgi, opt => opt.MapFrom(src => src.Characteristics.Felgi))
                .ForMember(dto => dto.Color, opt => opt.MapFrom(src => src.Characteristics.Color));


        }
    }
}
