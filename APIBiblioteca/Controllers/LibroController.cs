using APIBiblioteca.DAL.Interfaces;
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
    }
}
