
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
    public class LocalidadController : ControllerBase
    {
        private readonly ILocalidadRepository _localidadRepository;

        public LocalidadController(ILocalidadRepository localidadRepository)
        {
            _localidadRepository = localidadRepository;
        }

        [HttpGet]
        [Route("GetLocalidad")]
        public async Task<IActionResult> GetLocalidad()
        {
            var localidad = await _localidadRepository.GetCapacitaciones();
            return Ok(localidad);
        }

        [HttpGet]
        [Route("GetLocalidadById/{id}")]
        public async Task<IActionResult> GetLocalidadById(int id)
        {
            var localidad = await _localidadRepository.GetLocalidadById(id);

            if (localidad == null)
                return NotFound();

            return Ok(localidad);
        }

        [HttpPost]
        [Route("InsertLocalidad")]
        public async Task<IActionResult> InsertLocalidad(Localidad localidad)
        {
            await _localidadRepository.InsertLocalidad(localidad);

            return Ok(localidad);
        }

        [HttpPut]
        [Route("UpdateLocalidad")]
        public async Task<IActionResult> UpdateLocalidad(Localidad localidad)
        {
            var result = await _localidadRepository.UpdateLocalidad(localidad);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }

        //Intentar no usar delete
        [HttpDelete]
        [Route("DeleteLocalidad/{id}")]
        public async Task<IActionResult> DeleteLocalidad(int id)
        {
            var result = await _localidadRepository.DeleteLocalidad(id);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }
    }
}
