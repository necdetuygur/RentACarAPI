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
    public class KiralamasController : ControllerBase
    {
        private readonly IDapperService<Kiralama> _dapperKiralamaService;
        private readonly IDapperService<Araba> _dapperArabaService;
        private readonly IDapperService<Alici> _dapperAliciService;
        private readonly IMapper _mapper;
        public KiralamasController(IDapperService<Kiralama> dapperKiralamaService, IDapperService<Araba> dapperArabaService, IDapperService<Alici> dapperAliciService, IMapper mapper)
        {
            _dapperKiralamaService = dapperKiralamaService;
            _dapperArabaService = dapperArabaService;
            _dapperAliciService = dapperAliciService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [SwaggerOperation(Summary = "Kiralama ve kiralamaya bağlı arabaları ve alıcıları verir.", Description = "Kiralama ve kiralamaya bağlı arabaları ve alıcıları verir.")]
        public async Task<ActionResult<KiralamaDto>> GetAll()
        {
            try
            {
                var kiralamas = (await _dapperKiralamaService.QueryAsync("SELECT * FROM Kiralama")).ToList();
                foreach (Kiralama kiralama in kiralamas)
                {
                    var alicis = (await _dapperAliciService.QueryAsync($"SELECT * FROM Alici WHERE AliciID = {kiralama.AliciID}")).ToList();
                    kiralama.Alicis = alicis;

                    var arabas = (await _dapperArabaService.QueryAsync($"SELECT * FROM Araba WHERE ArabaID = {kiralama.ArabaID}")).ToList();
                    kiralama.Arabas = arabas;
                }
                return Ok(kiralamas);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Kiralama ve kiralamaya bağlı arabaları ve alıcıları kullanıcı tarafından verilen id'ye göre verir.", Description = "Firma ve kiralamaya bağlı arabaları ve alıcıları kullanıcı tarafından verilen id'ye göre verir.")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var kiralama = await _dapperKiralamaService.QueryFirstAsync($"SELECT * FROM Kiralama WHERE KiralamaID = {id}");

                var alici = (await _dapperAliciService.QueryAsync($"SELECT * FROM Alici WHERE AliciID = {kiralama.AliciID}")).ToList();
                kiralama.Alicis = alici;

                var araba = (await _dapperArabaService.QueryAsync($"SELECT * FROM Araba WHERE ArabaID = {kiralama.ArabaID}")).ToList();
                kiralama.Arabas = araba;

                return Ok(kiralama);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [SwaggerOperation(Summary = "Kullanıcı tarafından girilen bilgilere göre kiralama bilgilerini kaydeder.", Description = "Kullanıcı tarafından girilen bilgilere göre kiralama bilgilerini kaydeder.")]
        public async Task<IActionResult> Save(KiralamaDto kiralamaDto)
        {
            try
            {
                string sql = @"
                    INSERT INTO
                        Kiralama
                            (AliciID, ArabaID, BaslangicTarihi, BitisTarihi)
                    VALUES
                        (@AliciID, @ArabaID, @BaslangicTarihi, @BitisTarihi)
                ";
                object param = new
                {
                    AliciID = kiralamaDto.AliciID,
                    ArabaID = kiralamaDto.ArabaID,
                    BaslangicTarihi = kiralamaDto.BaslangicTarihi,
                    BitisTarihi = kiralamaDto.BitisTarihi
                };
                await _dapperKiralamaService.ExecuteAsync(sql, param);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [SwaggerOperation(Summary = "Kullanıcı tarafından girilen bilgilere göre kiralama bilgilerini günceller.", Description = "Kullanıcı tarafından girilen bilgilere göre kiralama bilgilerini günceller.")]
        public IActionResult Update(KiralamaDto kiralamaDto)
        {
            try
            {
                string sql = @"
                    UPDATE
                        Kiralama
                    SET
                        AliciID = @AliciID,
                        ArabaID = @ArabaID,
                        BaslangicTarihi = @BaslangicTarihi,
                        BitisTarihi = @BitisTarihi,
                        TeslimTarihi = @TeslimTarihi
                    WHERE
                        KiralamaID = @KiralamaID
                ";
                object param = new
                {
                    KiralamaID = kiralamaDto.KiralamaID,
                    AliciID = kiralamaDto.AliciID,
                    ArabaID = kiralamaDto.ArabaID,
                    BaslangicTarihi = kiralamaDto.BaslangicTarihi,
                    BitisTarihi = kiralamaDto.BitisTarihi,
                    TeslimTarihi = kiralamaDto.TeslimTarihi
                };
                _dapperKiralamaService.Execute(sql, param);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Kullanıcı tarafından girilen kiralama id'ye göre seçilen kiralama bilgisini siler.", Description = "Kullanıcı tarafından girilen kiralama id'ye göre seçilen kiralama bilgisini siler.")]
        public IActionResult Remove(int id)
        {
            try
            {
                _dapperKiralamaService.QueryAsync($"DELETE FROM Kiralama WHERE KiralamaID = {id}");
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
