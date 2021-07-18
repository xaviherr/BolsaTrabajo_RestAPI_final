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
    public class PostulacionController: ControllerBase
    {
        private readonly IPostulacionRepository _postulacionRepository;

        public PostulacionController(IPostulacionRepository postulacionRepository)
        {
            _postulacionRepository = postulacionRepository;
        }

        [HttpGet]
        [Route("GetPostulacion")]
        public async Task<IActionResult> GetPostulacion()
        {
            var postulacion = await _postulacionRepository.GetPostulacion();
            return Ok(postulacion);
        }

        [HttpGet]
        [Route("GetPostulacionById/{id}")]
        public async Task<IActionResult> GetPostulacionById(int id)
        {
            var postulacion = await _postulacionRepository.GetPostulacionById(id);

            if (postulacion == null)
                return NotFound();

            return Ok(postulacion);
        }

        [HttpPost]
        [Route("InsertPostulacion")]
        public async Task<IActionResult> InsertPostulacion(Postulacion postulacion)
        {
            await _postulacionRepository.InsertPostulacion(postulacion);

            return Ok(postulacion);
        }

        [HttpPut]
        [Route("UpdatePostulacion")]
        public async Task<IActionResult> UpdatePostulacion(Postulacion postulacion)
        {
            var result = await _postulacionRepository.UpdatePostulacion(postulacion);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }

        //Intentar no usar delete
        [HttpDelete]
        [Route("DeletePostulacion/{id}")]
        public async Task<IActionResult> DeletePostulacion(int id)
        {
            var result = await _postulacionRepository.DeletePostulacion(id);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }
    }
}
