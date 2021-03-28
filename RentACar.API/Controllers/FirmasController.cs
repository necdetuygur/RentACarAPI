using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.API.DTOs;
using RentACar.Core.Models;
using RentACar.Core.Services;
using RentACar.Service.Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmasController : ControllerBase
    {
        private readonly IDapperService<Firma> _dapperFirmaService;
        private readonly IDapperService<Araba> _dapperArabaService;
        private readonly IMapper _mapper;
        public FirmasController(IDapperService<Firma> dapperFirmaService, IDapperService<Araba> dapperArabaService, IMapper mapper)
        {
            _dapperFirmaService = dapperFirmaService;
            _dapperArabaService = dapperArabaService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [SwaggerOperation(Summary = "Firma ve firmaya bağlı arabaları verir.", Description = "Firma ve firmaya bağlı arabaları verir.")]
        public async Task<ActionResult<List<FirmaDto>>> GetAll()
        {
            try
            {
                var firmas = (await _dapperFirmaService.QueryAsync("SELECT * FROM Firma")).ToList();
                foreach (Firma firma in firmas)
                {
                    var arabas = (await _dapperArabaService.QueryAsync($"SELECT * FROM Araba WHERE FirmaID = {firma.FirmaID}")).ToList();
                    firma.Arabas = arabas;
                }
                return Ok(firmas);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Firma ve firmaya bağlı arabaları kullanıcı tarafından verilen id'ye göre verir.", Description = "Firma ve firmaya bağlı arabaları kullanıcı tarafından verilen id'ye göre verir.")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var firma = await _dapperFirmaService.QueryFirstAsync($"SELECT * FROM Firma WHERE FirmaID = {id}");
                var araba = (await _dapperArabaService.QueryAsync($"SELECT * FROM Araba WHERE FirmaID = {firma.FirmaID}")).ToList();
                firma.Arabas = araba;
                return Ok(firma);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [SwaggerOperation(Summary = "Kullanıcı tarafından girilen bilgilere göre firma bilgilerini kaydeder.", Description = "Kullanıcı tarafından girilen bilgilere göre firma bilgilerini kaydeder.")]
        public async Task<IActionResult> Save(FirmaDto firmaDto)
        {
            try
            {
                string sql = @"
                    INSERT INTO
                        Firma
                            (Unvan, Telefon, Mail, Adres, VergiNo)
                    VALUES
                        (@Unvan, @Telefon, @Mail, @Adres, @VergiNo)
                ";
                object param = new
                {
                    Unvan = firmaDto.Unvan,
                    Telefon = firmaDto.Telefon,
                    Mail = firmaDto.Mail,
                    Adres = firmaDto.Adres,
                    VergiNo = firmaDto.VergiNo
                };
                await _dapperFirmaService.ExecuteAsync(sql, param);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [SwaggerOperation(Summary = "Kullanıcı tarafından girilen bilgilere göre firma bilgilerini günceller.", Description = "Kullanıcı tarafından girilen bilgilere göre firma bilgilerini günceller.")]
        public IActionResult Update(FirmaDto firmaDto)
        {
            try
            {
                string sql = @"
                    UPDATE
                        Firma
                    SET
                        Unvan = @Unvan,
                        Telefon = @Telefon,
                        Mail = @Mail,
                        Adres = @Adres,
                        VergiNo = @VergiNo
                    WHERE
                        FirmaID = @FirmaID
                ";
                object param = new
                {
                    FirmaID = firmaDto.FirmaID,
                    Unvan = firmaDto.Unvan,
                    Telefon = firmaDto.Telefon,
                    Mail = firmaDto.Mail,
                    Adres = firmaDto.Adres,
                    VergiNo = firmaDto.VergiNo
                };
                _dapperFirmaService.Execute(sql, param);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Kullanıcı tarafından girilen firma id'ye göre seçilen firmayı siler.", Description = "Kullanıcı tarafından girilen firma id'ye göre seçilen firmayı siler.")]
        public IActionResult Remove(int id)
        {
            try
            {
                _dapperFirmaService.QueryAsync($"DELETE FROM Firma WHERE FirmaID = {id}");
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
