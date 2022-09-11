using AutoMapper;
using Biblioteca.Domain.Command.Delete;
using Biblioteca.Domain.Command.Post;
using Biblioteca.Domain.Command.Put;
using Biblioteca.Domain.Query.GetAll;
using Biblioteca.Domain.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BibliotecaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BibliotecaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BibliotecaController(
            IMapper mapper,
            IMediator mediator
        )
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _mediator.Send(new GetLivroByIdQuery(id));

            if(response == null)
                return NotFound();

            return await Task.FromResult(Ok(response));            
        }

        [HttpGet()]
        public async Task<IActionResult> GetLivrosAsync() =>
            Ok(await _mediator.Send(new GetLivrosAllQuery()));

        [HttpPost()]
        public IActionResult AdicionarLivro( [FromBody] AddLivroCommand livro) =>
            Ok(_mediator.Send(livro));

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarLivroAsync(int id,[FromBody] AlterarLivroCommand livro)      
        {
            var checkLivro = await _mediator.Send(new GetLivroByIdQuery(id));

            if (checkLivro == null)
                return NotFound();

            return Ok(
                await _mediator.Send(livro.AddIdAsync(id))
            );           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirLivro(int id)      
        {
            var checkLivro = await _mediator.Send(new GetLivroByIdQuery(id));

            if (checkLivro == null)
                return NotFound();

            var excluirLivro = await _mediator.Send(
                _mapper.Map<DeletarLivroCommand>(checkLivro)
            );

            return Ok(excluirLivro);            
        }

    }
}