using AutoMapper;
using Biblioteca.Domain.Interface.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Query.GetAll
{
    public class GetLivrosAllQueryHandler : IRequestHandler<GetLivrosAllQuery, GetLivrosAllQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBibliotecaRepository _repositorio;

        public GetLivrosAllQueryHandler(
            IMapper mapper,
            IBibliotecaRepository repositorio
        )
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        public async Task<GetLivrosAllQueryResponse> Handle(GetLivrosAllQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var livros = await _repositorio.ListarBibliotecasAsync();

                var livrosResponse = _mapper.Map<IEnumerable<Models.Livro>>(livros);

                return new GetLivrosAllQueryResponse(livrosResponse);
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
        }
    }
}
