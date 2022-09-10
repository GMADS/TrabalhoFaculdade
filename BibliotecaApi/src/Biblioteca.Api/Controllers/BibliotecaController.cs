using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BibliotecaController : ControllerBase
    {
        //Usando a inteface, sempre fazer esse procedimento para injeção de dependencias. 
        private readonly IBibliotecaRepository _repositorio;

        /*Construtor, sempre qe mina class for instanciada terei que passa IBibliotecaRepository*/
        public BibliotecaController(IBibliotecaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("{id}")]
        public IActionResult ObterBiblioteca(int id)
        {
            try
            {
                var bibliotecaAntiga = _repositorio.ObterPorId(id);
                if(bibliotecaAntiga == null)
                {
                    return NotFound();
                }
                return Ok(bibliotecaAntiga);            
            }
            catch (System.Exception ex)
            {            
                throw ex;
            }
        }
        [HttpGet()]
        public IActionResult ObterBiblioteca()
        {
            var TodosOsLivros =  _repositorio.ListarBibliotecas();

            return Ok(TodosOsLivros);            
        }

        [HttpPost()]
        public IActionResult AdicionarLivro(Livros livro)
        {
            _repositorio.Adicionar(livro);
            return Ok();
        }

         [HttpPut("{id}")]
        public IActionResult AlterarLivro(int id,[FromBody] Livros livro)      
        {
            var bibliotecaAntiga = _repositorio.ObterPorId(id);
            if(bibliotecaAntiga == null)
            {
                return NotFound();
            }

            bibliotecaAntiga.NomeDoLivro = livro.NomeDoLivro;
            bibliotecaAntiga.NomeDoAutor = livro.NomeDoAutor;
            bibliotecaAntiga.NumeroDePaginas = livro.NumeroDePaginas; 
            _repositorio.Alterar(bibliotecaAntiga);
            return Ok();           
        }

         [HttpDelete("")]
        public IActionResult ExcluirLivro(int id)      
        {
            var biblioteca = _repositorio.ObterPorId(id);
            if(biblioteca == null)
            {
                return NotFound();
            }
            _repositorio.RemoverBiblioteca(biblioteca);

            return Ok();            
        }

    }
}