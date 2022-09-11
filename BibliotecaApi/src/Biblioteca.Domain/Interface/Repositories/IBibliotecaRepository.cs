using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interface.Repositories
{
    public interface IBibliotecaRepository
    {
        Task AlterarAsync(Livro biblioteca);
        Task<Livro> ObterPorIdAsync(int id);
        Task AdicionarAsync(Livro biblioteca);
        Task RemoverBibliotecaAsync(Livro biblioteca);
        Task<IEnumerable<Livro>> ListarBibliotecasAsync();
    }
}