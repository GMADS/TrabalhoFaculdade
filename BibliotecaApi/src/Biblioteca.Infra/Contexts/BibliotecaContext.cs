using Microsoft.EntityFrameworkCore;
using Biblioteca.Domain;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Infra.Contexts
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {

        }

        public DbSet<Livro> Bibliotecas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().ToTable("Livros");
            modelBuilder.Entity<Livro>().Property(x => x.Id);
            modelBuilder.Entity<Livro>().Property(x => x.NomeDoAutor);
            modelBuilder.Entity<Livro>().Property(x => x.NomeDoLivro);
            modelBuilder.Entity<Livro>().Property(x => x.NumeroDePaginas);
        }

    }
}