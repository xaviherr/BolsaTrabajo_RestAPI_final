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
    public class ReclutadorController: ControllerBase
    {
        private readonly IReclutadorRepository _reclutadorRepository;

        public ReclutadorController(IReclutadorRepository reclutadorRepository)
        {
            _reclutadorRepository = reclutadorRepository;
        }

        [HttpGet]
        [Route("GetReclutador")]
        public async Task<IActionResult> GetReclutador()
        {
            var reclutador = await _reclutadorRepository.GetReclutador();
            return Ok(reclutador);
        }

        [HttpGet]
        [Route("GetReclutadorById/{id}")]
        public async Task<IActionResult> GetReclutadorById(int id)
        {
            var reclutador = await _reclutadorRepository.GetReclutadorById(id);

            if (reclutador == null)
                return NotFound();

            return Ok(reclutador);
        }

        [HttpPost]
        [Route("InsertReclutador")]
        public async Task<IActionResult> InsertReclutador(Reclutador reclutador)
        {
            await _reclutadorRepository.InsertReclutador(reclutador);

            return Ok(reclutador);
        }

        [HttpPut]
        [Route("UpdateReclutador")]
        public async Task<IActionResult> UpdateReclutador(Reclutador reclutador)
        {
            var result = await _reclutadorRepository.UpdateReclutador(reclutador);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }

        //Intentar no usar delete
        [HttpDelete]
        [Route("DeleteReclutador/{id}")]
        public async Task<IActionResult> DeleteReclutador(int id)
        {
            var result = await _reclutadorRepository.DeleteReclutador(id);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }

    }
}
