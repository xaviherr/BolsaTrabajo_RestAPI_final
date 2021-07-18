using BolsaTrabajo_Domain.Core.Entities;
using BolsaTrabajo_Domain.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaTrabajo_RestAPI.Controllers
{
    public class ReferenciaLaboralController : Controller
    {
        private readonly IReferenciaLaboralRepository _referenciaLaboralRepository;

            public ReferenciaLaboralController(IReferenciaLaboralRepository referenciaLaboralRepository)
            {
                _referenciaLaboralRepository = referenciaLaboralRepository;
            }

            [HttpGet]
            [Route("GetReferenciaLaboral")]
            public async Task<IActionResult> GetReferenciaLaboral()
            {
                var referenciaLaboral = await _referenciaLaboralRepository.GetReferenciaLaboral();
                return Ok(referenciaLaboral);
            }

            [HttpGet]
            [Route("GetReferenciaLaboralById/{id}")]
            public async Task<IActionResult> GetCapacitacionById(int id)
            {
                var referenciaLaboral = await _referenciaLaboralRepository.GetReferenciaLaboralById(id);

                if (referenciaLaboral == null)
                    return NotFound();

                return Ok(referenciaLaboral);
            }

            [HttpPost]
            [Route("InsertReferenciaLaboral")]
            public async Task<IActionResult> InsertReferenciaLaboral(ReferenciaLaboral referenciaLaboral)
            {
                await _referenciaLaboralRepository.InsertReferenciaLaboral(referenciaLaboral);

                return Ok(referenciaLaboral);
            }

            [HttpPut]
            [Route("UpdateReferenciaLaboral")]
            public async Task<IActionResult> UpdateReferenciaLaboral(ReferenciaLaboral referenciaLaboral)
            {
                var result = await _referenciaLaboralRepository.UpdateReferenciaLaboral(referenciaLaboral);
                if (!result)
                    return BadRequest();

                return Ok(new { result = "Success" });
            }

            //Intentar no usar delete
            [HttpDelete]
            [Route("DeleteReferenciaLaboral/{id}")]
            public async Task<IActionResult> DeleteReferenciaLaboral(int id)
            {
                var result = await _referenciaLaboralRepository.DeleteReferenciaLaboral(id);
                if (!result)
                    return BadRequest();

                return Ok(new { result = "Success" });
            }
        }
    
}
