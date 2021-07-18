using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolsaTrabajo_Domain.Core.Interfaces;
using BolsaTrabajo_Domain.Core.Entities;
using AutoMapper;
using BolsaTrabajo_Domain.Core.DTOs;

namespace BolsaTrabajo_RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class postulanteController : ControllerBase
    {
        private readonly IPostulanteRepository _postulanteRepository;
        private readonly IMapper _mapper;


        public postulanteController(IPostulanteRepository posturlanteRepository, IMapper mapper) { 

            _postulanteRepository = posturlanteRepository;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("GetPostulante")]
        public async Task<IActionResult> GetPostulante()
        {
            var customers = await _postulanteRepository.GetPostulante();
            return Ok(customers);

        }

       /* [HttpPut]
        [Route("PutPostulante")]
        public async Task<IActionResult> PutCustomer(PostulanteDTO postulanteDTO)
        {

            var postulante = _mapper.Map<Postulante>(postulanteDTO);

            var result = await _postulanteRepository.UpdatPostulante(postulante);
            if (!result)
                return BadRequest();
            return Ok(new { result = "Success" });
        }*/

        [HttpPost]
        [Route("PostPostulante")]
        public async Task<IActionResult> PostPostulante([FromBody]PostulanteDTO PostulanteDTO)
        {
            var customer = _mapper.Map<Postulante>(PostulanteDTO);

            await _postulanteRepository.InsertPostulante(customer);

            return Ok(customer);
        }



    }
}
