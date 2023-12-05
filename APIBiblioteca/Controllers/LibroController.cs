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
    public class LibroController : ControllerBase
    {
        private readonly IGenericRepository<Libro> _repository;
        private readonly IMapper _mapper;

        public LibroController(IGenericRepository<Libro> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetLibro")]
        public async Task<ActionResult<LibroDTO>> Obtener(int id)
        {
            var libro = await _repository.Obtener(id);
            if (libro == null)
            {
                return NotFound();
            }
            var libroDTO = _mapper.Map<LibroDTO>(libro);
            return Ok(libroDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(LibroCreacionDTO libroCreacionDTO)
        {
            var libro = _mapper.Map<Libro>(libroCreacionDTO);

            var resultado = await _repository.Insertar(libro);

            if (!resultado)
            {
                return NotFound();
            }
            var dto = _mapper.Map<LibroDTO>(libro);
            return Ok(dto);
        }

    }
}
