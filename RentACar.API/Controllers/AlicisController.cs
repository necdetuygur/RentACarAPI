using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.API.DTOs;
using RentACar.Core.Models;
using RentACar.Core.Services;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(Summary = "Alıcı bilgilerinin tümünü verir.", Description = "Alıcı bilgilerinin tümünü verir.")]
        public async Task<IActionResult> GetAll()
        {
            var alicis = await _aliciService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AliciDto>>(alicis));
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Kullanıcı tarafından verilen id'ye göre alıcı bilgisini verir.", Description = "Kullanıcı tarafından verilen id'ye göre alıcı bilgisini verir.")]
        public async Task<IActionResult> GetById(int id)
        {
            var alici = await _aliciService.GetByIdAsync(id);
            return Ok(_mapper.Map<AliciDto>(alici));
        }

        [Authorize]
        [HttpPost]
        [SwaggerOperation(Summary = "Kullanıcı tarafından girilen bilgilere göre alıcı bilgilerini kaydeder.", Description = "Kullanıcı tarafından girilen bilgilere göre alıcı bilgilerini kaydeder.")]
        public async Task<IActionResult> Save(AliciDto aliciDto)
        {
            var Alici = await _aliciService.AddAsync(_mapper.Map<Alici>(aliciDto));
            return Created(string.Empty, _mapper.Map<AliciDto>(Alici));
        }

        [Authorize]
        [HttpPut]
        [SwaggerOperation(Summary = "Kullanıcı tarafından girilen bilgilere göre alıcı bilgilerini günceller.", Description = "Kullanıcı tarafından girilen bilgilere göre alıcı bilgilerini günceller.")]
        public IActionResult Update(AliciDto aliciDto)
        {
            var Alici = _aliciService.Update(_mapper.Map<Alici>(aliciDto));
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Kullanıcı tarafından girilen alıcı id'ye göre seçilen arabayı siler.", Description = "Kullanıcı tarafından girilen alıcı id'ye göre seçilen arabayı siler.")]
        public IActionResult Remove(int id)
        {
            var alici = _aliciService.GetByIdAsync(id).Result;
            _aliciService.Remove(alici);
            return NoContent();
        }
    }
}
