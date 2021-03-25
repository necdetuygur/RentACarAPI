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
    public class FirmasController : ControllerBase
    {
        private readonly IDapperService<Firma> _dapperService;
        private readonly IMapper _mapper;
        public FirmasController(IDapperService<Firma> dapperService, IMapper mapper)
        {
            _dapperService = dapperService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Firma>>> GetAll()
        {
            try
            {
                var firmas = await _dapperService.QueryAsync("SELECT * FROM Firma");
                return Ok(_mapper.Map<IEnumerable<FirmaDto>>(firmas));
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
                var firma = await _dapperService.QueryFirstAsync($"SELECT * FROM Firma WHERE FirmaID = {id}");
                return Ok(_mapper.Map<FirmaDto>(firma));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
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
                _dapperService.QueryAsync($"DELETE FROM Firma WHERE FirmaID = {id}");
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
