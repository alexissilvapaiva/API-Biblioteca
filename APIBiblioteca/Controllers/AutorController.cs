using APIBiblioteca.DAL.Interfaces;
using APIBiblioteca.DTO;
using APIBiblioteca.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBiblioteca.Controllers
{
    [Route("api/autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IGenericRepository<Autor> _repository;
        private readonly IMapper _mapper;

        public AutorController(IGenericRepository<Autor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDTO>>> ObtenerTodos()
        {
            var actores = await _repository.ObtenerTodos();
            var autoresDTO = _mapper.Map<IEnumerable<AutorDTO>>(actores);
            return Ok(autoresDTO);
        }

        [HttpGet("{id}", Name ="GetAutor")]
        public async Task<ActionResult<AutorDTO>> Obtener(int id)
        {
            var autor = await _repository.Obtener(id);
            if(autor == null)
            {
                return NotFound();
            }
            var autorDTO = _mapper.Map<AutorDTO>(autor);
            return Ok(autorDTO);
        }

        [HttpPost]
        public async Task<ActionResult>Crear(AutorCreacionDTO autorCreacionDTO)
        {
            var autor = _mapper.Map<Autor>(autorCreacionDTO);

            var resultado = await _repository.Insertar(autor);

            if (!resultado)
            {
                return NotFound();
            }
            var dto = _mapper.Map<AutorCreacionDTO>(autor);
            return Ok(dto);
        }
    }
}
