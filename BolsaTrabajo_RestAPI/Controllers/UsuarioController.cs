using BolsaTrabajo_Domain.Core.Entities;
using BolsaTrabajo_Domain.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaTrabajo_RestAPI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("GetUsuario")]
        public async Task<IActionResult> GetReferenciaLaboral()
        {
            var usuario = await _usuarioRepository.GetUsuario();
            return Ok(usuario);
        }

        [HttpGet]
        [Route("GetUsuarioById/{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioById(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        [Route("InsertUsuario")]
        public async Task<IActionResult> InsertUsuario(Usuario usuario)
        {
            await _usuarioRepository.InsertUsuario(usuario);

            return Ok(usuario);
        }

        [HttpPut]
        [Route("UpdateUsuario")]
        public async Task<IActionResult> UpdateUsuario(Usuario usuario)
        {
            var result = await _usuarioRepository.UpdateUsuario(usuario);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }

        //Intentar no usar delete
        [HttpDelete]
        [Route("DeleteUsuario/{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var result = await _usuarioRepository.DeleteUsuario(id);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }
    }

}


