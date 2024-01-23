using AutoMapper;
using CarSharingDomain.DomainModels;
using CarSharingDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.Commands
{
    public class CreateCarSharingCommandHandler : IRequestHandler<CreateCarSharingCommand>
    {
        private readonly ICarSharingRepositories _carSharingRepositories;
        private readonly IMapper _mapper;

        public CreateCarSharingCommandHandler(ICarSharingRepositories carSharingRepositories,IMapper mapper)
        {
            _carSharingRepositories = carSharingRepositories;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateCarSharingCommand request, CancellationToken cancellationToken)
        {
            var CarSharing = _mapper.Map<CarProfileModel>(request);
            await _carSharingRepositories.Create(CarSharing);

            return Unit.Value;
        }
    }
}
