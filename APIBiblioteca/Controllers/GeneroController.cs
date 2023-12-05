using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGenericRepository<Autor> _repository;
        private readonly IMapper _mapper;

        public AutorController(IGenericRepository<Autor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
