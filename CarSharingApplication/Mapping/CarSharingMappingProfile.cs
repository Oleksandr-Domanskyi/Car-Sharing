using AutoMapper;
using CarSharingApplication.DataTransferObjects;
using CarSharingDomain.DomainModels;
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
            CreateMap<CarProfileModel, CarSharingProfileModelObject>()
                .ForMember(dto => dto.Silnik, opt => opt.MapFrom(src => src.Characteristics.Silnik))
                .ForMember(dto => dto.Tapicerka, opt => opt.MapFrom(src => src.Characteristics.Tapicerka))
                .ForMember(dto => dto.Felgi, opt => opt.MapFrom(src => src.Characteristics.Felgi))
                .ForMember(dto => dto.Color, opt => opt.MapFrom(src => src.Characteristics.Color));

            CreateMap<CarSharingProfileModelObject, CarProfileModel>()
                .ForMember(dto => dto.Characteristics, opt => opt.MapFrom(src => new CarChatacteristics()
                {
                    Silnik = src.Silnik,
                    Color = src.Color,
                    Felgi = src.Felgi,
                    Tapicerka = src.Tapicerka
                }))
                 .ForMember(dest => dest.Image, opt => opt.MapFrom(src => MapImages(src.Images)));
            
        }
        private List<Image> MapImages(List<IFormFile> images)
        {
            // Map IFormFile instances to Image instances
            return images.Select(image => new Image
            {
                Name = image.FileName,
                FileType = image.ContentType,
                DataFile = GetBytesFromIFormFile(image)
            }).ToList();
        }

        private byte[] GetBytesFromIFormFile(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
