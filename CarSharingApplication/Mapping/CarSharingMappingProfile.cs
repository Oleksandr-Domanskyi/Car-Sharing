using AutoMapper;
using CarSharingApplication.DataTransferObjects;
using CarSharingDomain.DomainModels;
using CarSharingApplication.Handler.ImageHandler;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.Mapping
{
    public class CarSharingMappingProfile:Profile
    {

        public CarSharingMappingProfile()
        {
            CreateMap<CarProfileModel, CreateCarSharingProfileModelObject>()
                .ForMember(dto => dto.Silnik, opt => opt.MapFrom(src => src.Characteristics.Silnik))
                .ForMember(dto => dto.Tapicerka, opt => opt.MapFrom(src => src.Characteristics.Tapicerka))
                .ForMember(dto => dto.Felgi, opt => opt.MapFrom(src => src.Characteristics.Felgi))
                .ForMember(dto => dto.Color, opt => opt.MapFrom(src => src.Characteristics.Color));

            CreateMap<CreateCarSharingProfileModelObject, CarProfileModel>()
                .ForMember(dto => dto.Characteristics, opt => opt.MapFrom(src => new CarChatacteristics()
                {
                    Silnik = src.Silnik,
                    Color = src.Color,
                    Felgi = src.Felgi,
                    Tapicerka = src.Tapicerka
                }))
                 .ForMember(dest => dest.Image, opt => opt.MapFrom(src => ImageHandler.MapImages(src.Images)));

            CreateMap<CarProfileModel, ShowCarSharingProfileModelObject>()
             .ForMember(dest => dest.Silnik, opt => opt.MapFrom(src => src.Characteristics.Silnik))
             .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Characteristics.Color))
             .ForMember(dest => dest.Felgi, opt => opt.MapFrom(src => src.Characteristics.Felgi))
             .ForMember(dest => dest.Tapicerka, opt => opt.MapFrom(src => src.Characteristics.Tapicerka))
             .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Image));

        }
       

        
    }
}
