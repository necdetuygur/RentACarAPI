using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.API.DTOs;
using RentACar.Core.Models;
using RentACar.Core.Services;
using RentACar.Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KiralamasController : ControllerBase
    {
        private readonly IDapperService<Kiralama> _dapperService;
        private readonly IMapper _mapper;
        public KiralamasController(IDapperService<Kiralama> dapperService, IMapper mapper)
        {
            _dapperService = dapperService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kiralama>>> GetAll()
        {
            try
            {
                var kiralamas = await _dapperService.QueryAsync("SELECT * FROM Kiralama");
                return Ok(_mapper.Map<IEnumerable<KiralamaDto>>(kiralamas));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var kiralama = await _dapperService.QueryFirstAsync($"SELECT * FROM Kiralama WHERE KiralamaID = {id}");
                return Ok(_mapper.Map<KiralamaDto>(kiralama));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
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
                await _dapperService.ExecuteAsync(sql, param);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
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
                _dapperService.Execute(sql, param);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _dapperService.QueryAsync($"DELETE FROM Kiralama WHERE KiralamaID = {id}");
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
