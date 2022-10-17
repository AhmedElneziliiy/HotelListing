using AutoMapper;
using HotelListing.DTOS;
using HotelListing.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCoutries()
        {
            try
            {
                var countries =await _unitOfWork.Countries.GetAll();
                var result = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong{nameof(GetCoutries)} ");
                return StatusCode(500, "internal server error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCoutry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(c=>c.Id==id,new List<string> {"Hotels"});
                var result = _mapper.Map<CountryDTO>(country);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong{nameof(GetCoutry)}");
                return StatusCode(500, "internal server error");
            }
        }




    }
}
