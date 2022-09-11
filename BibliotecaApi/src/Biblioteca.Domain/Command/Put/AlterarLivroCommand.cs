using MediatR;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Command.Put
{
    public class AlterarLivroCommand : IRequest
    {
        public int Id { get; set; }
        public string NomeDoLivro { get; set; }
        public string NomeDoAutor { get; set; }
        public int NumeroDePaginas { get; set; }
    }
}
