using AutoMapper;
using MediatR;

namespace Biblioteca.Domain.Command.Delete
{
    public class DeletarLivroCommand : IRequest
    {
        public int Id { get; set; }
        public string NomeDoLivro { get; set; }
        public string NomeDoAutor { get; set; }
        public int NumeroDePaginas { get; set; }
    }
}
