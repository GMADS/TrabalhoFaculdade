using MediatR;

namespace Biblioteca.Domain.Command.Post
{
    public class AddLivroCommand : IRequest
    {
        public string NomeDoLivro { get; set; }
        public string NomeDoAutor { get; set; }
        public int NumeroDePaginas { get; set; }
    }
}
