using BolsaTrabajo_Domain.Core.Entities;
using BolsaTrabajo_Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaTrabajo_RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController: Controller
    {
        private readonly IOfertaRepository _ofertaRepository;

        public OfertaController(IOfertaRepository ofertaRepository)
        {
            _ofertaRepository = ofertaRepository;
        }

        [HttpGet]
        [Route("GetOferta")]
        public async Task<IActionResult> GetOferta()
        {
            var oferta = await _ofertaRepository.GetOferta();
            return Ok(oferta);
        }

        [HttpGet]
        [Route("GetOfertaById/{id}")]
        public async Task<IActionResult> GetOfertaById(int id)
        {
            var oferta = await _ofertaRepository.GetOfertaById(id);

            if (oferta == null)
                return NotFound();

            return Ok(oferta);
        }

        [HttpPost]
        [Route("InsertOferta")]
        public async Task<IActionResult> InsertOferta(Oferta oferta)
        {
            await _ofertaRepository.InsertOferta(oferta);

            return Ok(oferta);
        }

        [HttpPut]
        [Route("UpdateOferta")]
        public async Task<IActionResult> UpdateOferta(Oferta oferta)
        {
            var result = await _ofertaRepository.UpdateOferta(oferta);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }

        //Intentar no usar delete
        [HttpDelete]
        [Route("DeleteOferta/{id}")]
        public async Task<IActionResult> DeleteOferta(int id)
        {
            var result = await _ofertaRepository.DeleteOferta(id);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }
    }
}
