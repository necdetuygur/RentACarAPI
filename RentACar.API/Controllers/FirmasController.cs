using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.API.DTOs;
using RentACar.Core.Models;
using RentACar.Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmasController : ControllerBase
    {
        private readonly FirmaDapperService _firmaDapperService;
        private readonly IMapper _mapper;
        public FirmasController(FirmaDapperService firmaDapperService, IMapper mapper)
        {
            _firmaDapperService = firmaDapperService;
            _mapper = mapper;
        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Firma>>> GetAll()
        {
            var firmas = await _firmaDapperService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<FirmaDto>>(firmas));
        }
    }
}
