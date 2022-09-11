using AutoMapper;
using Biblioteca.Domain.Interface.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Query.GetById
{
    public class GetLivroByIdQueryHandler : IRequestHandler<GetLivroByIdQuery, GetLivroByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBibliotecaRepository _repositorio;

        public GetLivroByIdQueryHandler(
            IMapper mapper,
            IBibliotecaRepository repositorio
        )
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }
            

        public async Task<GetLivroByIdQueryResponse> Handle(GetLivroByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<GetLivroByIdQueryResponse>(await _repositorio.ObterPorIdAsync(request.Id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
            
    }
}
