using CarSharingApplication.CarSharing.Commands;
using CarSharingApplication.CarSharing.Queries.GetAllCarSharing;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Car_Sharing_MVC.Controllers
{
    public class CarSharingController : Controller
    {
        private readonly IMediator _mediator;

        public CarSharingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var CarSharing = await _mediator.Send(new GetAllCarSharingQuery());
            return View(CarSharing);
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
