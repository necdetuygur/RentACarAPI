using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.API.DTOs;
using RentACar.Core.Models;
using RentACar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlicisController : ControllerBase
    {
        private readonly IDapperService<Alici> _aliciDapperService;
        private readonly IService<Alici> _aliciService;
        private readonly IMapper _mapper;
        public AlicisController(IDapperService<Alici> dapperService, IService<Alici> service, IMapper mapper)
        {
            _aliciDapperService = dapperService;
            _aliciService = service;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alicis = await _aliciService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AliciDto>>(alicis));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var alici = await _aliciService.GetByIdAsync(id);
            return Ok(_mapper.Map<AliciDto>(alici));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save(AliciDto aliciDto)
        {
            var Alici = await _aliciService.AddAsync(_mapper.Map<Alici>(aliciDto));
            return Created(string.Empty, _mapper.Map<AliciDto>(Alici));
        }

        [Authorize]
        [HttpPut]
        public IActionResult Update(AliciDto aliciDto)
        {
            var Alici = _aliciService.Update(_mapper.Map<Alici>(aliciDto));
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var alici = _aliciService.GetByIdAsync(id).Result;
            _aliciService.Remove(alici);
            return NoContent();
        }
    }
}
