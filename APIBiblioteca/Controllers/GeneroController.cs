using APIBiblioteca.DAL.Interfaces;
using APIBiblioteca.DTO;
using APIBiblioteca.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGenericRepository<Genero> _repository;
        private readonly IMapper _mapper;

        public GeneroController(IGenericRepository<Genero> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneroDTO>>> ObtenerTodos()
        {
            var generos = await _repository.ObtenerTodos();
            var generosDTO = _mapper.Map<IEnumerable<GeneroDTO>>(generos);
            return Ok(generosDTO);
        }

        [HttpPost]
        public async Task<ActionResult<GeneroDTO>> Crear([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = _mapper.Map<Genero>(generoCreacionDTO);
            await _repository.Insertar(genero);
            var generoDTO = _mapper.Map<GeneroCreacionDTO>(genero);
            return Ok(generoDTO);
        }

    }
}
