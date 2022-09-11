using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interface.Repositories;
using Biblioteca.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Repositories
{
    public class BibliotecaRepository : IBibliotecaRepository
    {
        private readonly BibliotecaContext _context;

        public BibliotecaRepository(BibliotecaContext context) =>
            _context = context;

        public async Task AdicionarAsync(Livro biblioteca)
        {
            _context.Add(biblioteca);
            _context.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task AlterarAsync(Livro biblioteca)
        {
            _context.Update(biblioteca).State = EntityState.Modified;
            _context.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Livro>> ListarBibliotecasAsync() =>
            await Task.FromResult(
                _context.Bibliotecas.ToList()
            );

        public async Task<Livro> ObterPorIdAsync(int id) =>
            await Task.FromResult(
                _context.Bibliotecas.FirstOrDefault(x => x.Id == id)
            );

        public async Task RemoverBibliotecaAsync(Livro biblioteca)
        {
            _context.Remove(biblioteca);
            _context.SaveChanges();

            await Task.CompletedTask;
        }
    }
}