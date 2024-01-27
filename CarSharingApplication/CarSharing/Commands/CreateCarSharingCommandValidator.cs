using CarSharingDomain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.Commands
{
    public class CreateCarSharingCommandValidator:AbstractValidator<CreateCarSharingCommand>
    {
        public CreateCarSharingCommandValidator(ICarSharingRepositories repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Name should have atleast 2 characters")
                .MaximumLength(40).WithMessage("Name should have maximum 40 characters");
               
            RuleFor(c => c.Description)
               .NotEmpty().WithMessage("Please Enter Description");

            RuleFor(c=>c.Images).Must(HaveValidImageTypes)
                .WithMessage("Invalid image type. Allowed types are: jpg, jpeg, png, gif");

            RuleFor(c => c.PricePerDay).NotEmpty().WithMessage("Please Enter Price");

            RuleFor(c => c.ContactNumber).NotEmpty().WithMessage("Please Enter your Contact Number");
            RuleFor(c => c.City).NotEmpty().WithMessage("Please Enter City");


        }
      

        private bool HaveValidImageTypes(List<IFormFile> images)
        {
            if (images == null || !images.Any())
            {
                return true;
            }

            var allowedImageTypes = new[] { "image/jpeg", "image/jpg", "image/png", "image/gif" };

            return images.All(image => allowedImageTypes.Contains(image.ContentType));
        }
    }
}
