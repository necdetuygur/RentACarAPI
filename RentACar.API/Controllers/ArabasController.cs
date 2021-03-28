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
    public class ArabasController : ControllerBase
    {
        private readonly IDapperService<Araba> _arabaDapperService;
        private readonly IService<Araba> _arabaService;
        private readonly IMapper _mapper;
        public ArabasController(IDapperService<Araba> dapperService, IService<Araba> service, IMapper mapper)
        {
            _arabaDapperService = dapperService;
            _arabaService = service;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [SwaggerOperation(Summary = "Araba bilgilerinin tümünü verir.", Description = "Araba bilgilerinin tümünü verir.")]
        public async Task<IActionResult> GetAll()
        {
            var arabas = await _arabaService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ArabaDto>>(arabas));
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Kullanıcı tarafından verilen id'ye göre araba bilgisini verir.", Description = "Kullanıcı tarafından verilen id'ye göre araba bilgisini verir.")]
        public async Task<IActionResult> GetById(int id)
        {
            var araba = await _arabaService.GetByIdAsync(id);
            return Ok(_mapper.Map<ArabaDto>(araba));
        }

        [Authorize]
        [HttpPost]
        [SwaggerOperation(Summary = "Kullanıcı tarafından girilen bilgilere göre araba bilgilerini kaydeder.", Description = "Kullanıcı tarafından girilen bilgilere göre araba bilgilerini kaydeder.")]
        public async Task<IActionResult> Save(ArabaDto arabaDto)
        {
            var newAraba = await _arabaService.AddAsync(_mapper.Map<Araba>(arabaDto));
            return Created(string.Empty, _mapper.Map<ArabaDto>(newAraba));
        }

        [Authorize]
        [HttpPut]
        [SwaggerOperation(Summary = "Kullanıcı tarafından girilen bilgilere göre araba bilgilerini günceller.", Description = "Kullanıcı tarafından girilen bilgilere göre araba bilgilerini günceller.")]
        public IActionResult Update(ArabaDto arabaDto)
        {
            var newAraba = _arabaService.Update(_mapper.Map<Araba>(arabaDto));
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Kullanıcı tarafından girilen araba id'ye göre seçilen arabayı siler.", Description = "Kullanıcı tarafından girilen araba id'ye göre seçilen arabayı siler.")]
        public IActionResult Remove(int id)
        {
            var araba = _arabaService.GetByIdAsync(id).Result;
            _arabaService.Remove(araba);
            return NoContent();
        }
    }
}
