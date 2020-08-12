using System.Collections.Generic;
using System.Threading.Tasks;
using MiniCarsales.API.Application.Cars.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniCarsales.API.Application.Cars.Queries;

namespace MiniCarsales.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper; 
        private readonly ILogger<CarController> _logger;

        public CarController(IMediator mediator, IMapper mapper, ILogger<CarController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [EnableCors("Corspolicy")]
        [HttpGet]
        public async Task<ActionResult<List<CarDto>>> GetCarsAsync()
        {
            var cars = await _mediator.Send(new QueryCarsRequest());
            
            return _mapper.Map<List<CarDto>>(cars);
        }

        [EnableCors("Corspolicy")]
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateCarAsync(CreateCarCommand commandDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = _mapper.Map<CreateCarCommand>(commandDto);
            return await _mediator.Send(command);
        }
    }
}
