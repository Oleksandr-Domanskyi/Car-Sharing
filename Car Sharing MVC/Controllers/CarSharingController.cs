using AutoMapper;
using CarSharingApplication.CarSharing.Commands.CreateCarSharing;
using CarSharingApplication.CarSharing.Commands.EditCarSharing;
using CarSharingApplication.CarSharing.Queries.GetAllCarSharing;
using CarSharingApplication.CarSharing.Queries.GetByNameCarSharing;
using CarSharingApplication.DataTransferObjects;
using CarSharingDomain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Car_Sharing_MVC.Controllers
{
    public class CarSharingController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICarSharingRepositories _carSharingRepositories;
        private readonly IMapper _mapper;

        public CarSharingController(IMediator mediator,ICarSharingRepositories carSharingRepositories,IMapper mapper)
        {
            _mediator = mediator;
            _carSharingRepositories = carSharingRepositories;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var carSharingList = await _mediator.Send(new GetAllCarSharingQuery());

            return View(carSharingList);
        }
        [HttpGet]
        public async Task<IActionResult> GetIndexImage(Guid imageId)
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
        [Route("CarSharing/{Id}/Details")]
        public async Task<IActionResult> Details(Guid Id)
        {
            var dto = await _mediator.Send(new GetByNameCarSharingQuery(Id));
            return View(dto);
        }
         [HttpGet]
        public async Task<IActionResult> GetDetailsImage(Guid imageId)
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
        [Route("CarSharing/{Id}/Edit")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var dto = await _mediator.Send(new GetByNameCarSharingQuery(Id));
            EditCarSharingCommand command =_mapper.Map<EditCarSharingCommand>(dto);
            return View(command);
        }
        [HttpPost]
        [Route("CarSharing/{Id}/Edit")]
        public async Task<IActionResult> Edit(Guid id , EditCarSharingCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Details));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCarSharingCommand command, [FromForm] List<IFormFile> images)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
