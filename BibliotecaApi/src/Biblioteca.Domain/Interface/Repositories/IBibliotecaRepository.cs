using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interface.Repositories
{
    public interface IBibliotecaRepository
    {
        Task AlterarAsync(Livros biblioteca);
        Task<Livros> ObterPorIdAsync(int id);
        Task AdicionarAsync(Livros biblioteca);
        Task RemoverBibliotecaAsync(Livros biblioteca);
        Task<IEnumerable<Livros>> ListarBibliotecasAsync();
    }
}