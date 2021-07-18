using AutoMapper;
using BolsaTrabajo_Domain.Core.DTOs;
using BolsaTrabajo_Domain.Core.Entities;
using BolsaTrabajo_Domain.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaTrabajo_RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacitacionController : ControllerBase
    {
        private readonly ICapacitacionRepository _capacitacionRepository;
        private readonly IMapper _mapper;
        public CapacitacionController(ICapacitacionRepository capacitacionRepository, IMapper mapper)
        {
            _capacitacionRepository = capacitacionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetCapacitaciones")]
        public async Task<IActionResult> GetCapacitaciones()
        {
            var capacitaciones = await _capacitacionRepository.GetCapacitaciones();
            return Ok(capacitaciones);
        }

        [HttpGet]
        [Route("GetCapacitacionById/{id}")]
        public async Task<IActionResult> GetCapacitacionById(int id)
        {
            var capacitacion = await _capacitacionRepository.GetCapacitacionById(id);

            if (capacitacion == null)
                return NotFound();

            return Ok(capacitacion);
        }

        [HttpPost]
        [Route("InsertCapacitacion")]
        public async Task<IActionResult> InsertCapacitacion(CapacitacionDTO capacitacionDTO)
        {

            var capacitacion = _mapper.Map<Capacitacion>(capacitacionDTO);

            await _capacitacionRepository.InsertCapacitacion(capacitacion);

            return Ok(capacitacion);
        }

        [HttpPut]
        [Route("UpdateCapacitacion")]
        public async Task<IActionResult> UpdateCapacitacion(Capacitacion capacitacion)
        {
            var result = await _capacitacionRepository.UpdateCapacitacion(capacitacion);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }

        //Intentar no usar delete
        [HttpDelete]
        [Route("DeleteCapacitacion/{id}")]
        public async Task<IActionResult> DeleteCapacitacion(int id)
        {
            var result = await _capacitacionRepository.DeleteCapacitacion(id);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }
    }
}
