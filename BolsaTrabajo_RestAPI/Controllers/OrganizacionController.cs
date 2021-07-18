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
    public class OrganizacionController : ControllerBase
    {
        private readonly IOrganizacionRepository _organizacionRepository;

        public OrganizacionController(IOrganizacionRepository organizacionRepository)
        {
            _organizacionRepository = organizacionRepository;
        }

        [HttpGet]
        [Route("GetOrganizacion")]
        public async Task<IActionResult> GetOrganizacion()
        {
            var organizacion = await _organizacionRepository.GetOrganizacion();
            return Ok(organizacion);
        }

        [HttpGet]
        [Route("GetOrganizacionById/{id}")]
        public async Task<IActionResult> GetOrganizacionById(int id)
        {
            var organizacion = await _organizacionRepository.GetOrganizacionById(id);

            if (organizacion == null)
                return NotFound();

            return Ok(organizacion);
        }

        [HttpPost]
        [Route("InsertOrganizacion")]
        public async Task<IActionResult> InsertOrganizacion(Organizacion organizacion)
        {
            await _organizacionRepository.InsertOrganizacion(organizacion);

            return Ok(organizacion);
        }

        [HttpPut]
        [Route("UpdateOrganizacion")]
        public async Task<IActionResult> UpdateOrganizacion(Organizacion organizacion)
        {
            var result = await _organizacionRepository.UpdateOrganizacion(organizacion);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }

        //Intentar no usar delete
        [HttpDelete]
        [Route("DeleteOrganizacion/{id}")]
        public async Task<IActionResult> DeleteOrganizacion(int id)
        {
            var result = await _organizacionRepository.DeleteOrganizacion(id);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }
    }
}
