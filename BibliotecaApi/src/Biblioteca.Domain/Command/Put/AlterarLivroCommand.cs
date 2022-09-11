using MediatR;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Command.Put
{
    public class AlterarLivroCommand : IRequest<AlterarLivroCommandResponse>
    {
        public int Id { get; set; }
        public string NomeDoLivro { get; set; }
        public string NomeDoAutor { get; set; }
        public int NumeroDePaginas { get; set; }

        public async Task AddIdAsync(int ind)
        {
            Id = Id;

            await Task.CompletedTask;
        }
    }
}
