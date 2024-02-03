using CarSharingApplication.CarSharing.Commands.CreateCarSharing;
using CarSharingApplication.CarSharing.Queries.GetAllCarSharing;
using CarSharingApplication.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.Extentions
{
    public static class ServiceApplicationExtentions
    {
        public static void AddServiceApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllCarSharingQuery));
            services.AddAutoMapper(typeof(CarSharingMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateCarSharingCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
