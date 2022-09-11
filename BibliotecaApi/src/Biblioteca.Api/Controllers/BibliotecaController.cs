using Biblioteca.Domain.Command.Post;
using Biblioteca.Domain.Entities;
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
        private readonly IMediator _mediator;

        public BibliotecaController(IMediator mediator) =>
            _mediator = mediator;

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
        public IActionResult AlterarLivro(int id,[FromBody] Livro livro)      
        {
            var bibliotecaAntiga = _mediator.ObterPorIdAsync(id);

            if(bibliotecaAntiga == null)
            {
                return NotFound();
            }

            bibliotecaAntiga.NomeDoLivro = livro.NomeDoLivro;
            bibliotecaAntiga.NomeDoAutor = livro.NomeDoAutor;
            bibliotecaAntiga.NumeroDePaginas = livro.NumeroDePaginas; 
            _mediator.Alterar(bibliotecaAntiga);
            return Ok();           
        }

         [HttpDelete("Del")]
        public IActionResult ExcluirLivro(int id)      
        {
            var biblioteca = _mediator.ObterPorIdAsync(id);
            if(biblioteca == null)
            {
                return NotFound();
            }
            _mediator.RemoverBiblioteca(biblioteca);

            return Ok();            
        }

    }
}