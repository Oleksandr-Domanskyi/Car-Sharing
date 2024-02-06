﻿using AutoMapper;
using CarSharingApplication.DataTransferObjects;
using CarSharingApplication.Handler.ImageHandler;
using CarSharingApplication.Mapping;
using CarSharingDomain.DomainModels;
using CarSharingDomain.DomainModels.Enums;
using CarSharingDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingProfileCommands.Commands.EditCarSharing
{
    public class EditCarSharingCommandHandler : IRequestHandler<EditCarSharingCommand>
    {
        private readonly ICarSharingRepositories _carSharingRepositories;
        private readonly IMapper _mapper;

        public EditCarSharingCommandHandler(ICarSharingRepositories carSharingRepositories, IMapper mapper)
        {
            _carSharingRepositories = carSharingRepositories;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EditCarSharingCommand request, CancellationToken cancellationToken)
        {
            var CarSharing = await _carSharingRepositories.GetByName(request.Id);
            if (CarSharing == null)
            {
                return Unit.Value;
            }
            var NewImagesParsing = ImageHandler.MapImages(request.NewImages!);

            CarSharing.Image.AddRange(NewImagesParsing);
            CarSharing.PricePerDay = request.PricePerDay;
            CarSharing.Description = request.Description;
            CarSharing.Name = request.Name;

            CarSharing.Characteristics.Engine = request.Characteristics?.Engine;
            CarSharing.Characteristics.Color = request.Characteristics?.Color;
            CarSharing.Characteristics.Upholstery = request.Characteristics?.Upholstery;
            CarSharing.Characteristics.Rims = request.Characteristics?.Rims;

            CarSharing.CarContactDetails.ContactNumber = request.ContactNumber;
            CarSharing.CarContactDetails.City = request.City;
            CarSharing.CarContactDetails.Coutry = request.Coutry != null ? Enum.Parse<Countries>(request.Coutry, true) : null;
            CarSharing.CarContactDetails.ValueMoney = Enum.Parse<ValueMoney>(request.ValueMoney.ToString()!, true);


            await _carSharingRepositories.SaveChanges();

            return Unit.Value;


        }
    }
}