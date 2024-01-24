using CarSharingApplication.CarSharing.Commands;
using CarSharingApplication.CarSharing.Queries.GetAllCarSharing;
using CarSharingDomain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Car_Sharing_MVC.Controllers
{
    public class CarSharingController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICarSharingRepositories _carSharingRepositories;

        public CarSharingController(IMediator mediator,ICarSharingRepositories carSharingRepositories)
        {
            _mediator = mediator;
            _carSharingRepositories = carSharingRepositories;
        }
        public async Task<IActionResult> Index()
        {
            var carSharingList = await _mediator.Send(new GetAllCarSharingQuery());

            return View(carSharingList);
        }
        [HttpGet]
        public async Task<IActionResult> GetImage(Guid imageId)
        {
            var image = await _carSharingRepositories.GetImageById(imageId);

            if (image != null)
            {
                return File(image.DataFile!, image.FileType!); 
            }
            else
            {
                return NotFound();
            }
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCarSharingCommand command, [FromForm] List<IFormFile> images)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
