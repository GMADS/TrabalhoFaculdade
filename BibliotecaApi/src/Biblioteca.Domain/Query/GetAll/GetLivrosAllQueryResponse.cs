using Biblioteca.Domain.Query.GetAll.Models;
using System.Collections.Generic;

namespace Biblioteca.Domain.Query.GetAll
{
    public class GetLivrosAllQueryResponse
    {
        public GetLivrosAllQueryResponse(IEnumerable<Livro> livros) =>
            Livros = livros;

        public IEnumerable<Livro> Livros { get; set; }
    }
}
