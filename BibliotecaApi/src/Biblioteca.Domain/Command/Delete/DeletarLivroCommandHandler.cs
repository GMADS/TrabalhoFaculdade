using AutoMapper;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interface.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Command.Delete
{
    public class DeletarLivroCommandHandler : IRequestHandler<DeletarLivroCommand>
    {
        private readonly IMapper _mapper;
        private readonly IBibliotecaRepository _repositorio;

        public DeletarLivroCommandHandler(
            IMapper mapper,
            IBibliotecaRepository repositorio
        )
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        public async Task<Unit> Handle(DeletarLivroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repositorio.RemoverBibliotecaAsync(
                    _mapper.Map<Livro>(request)
                );

                return Unit.Value;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
