using AutoMapper;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interface.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Command.Put
{
    public class AlterarLivroCommandHandler : IRequestHandler<AlterarLivroCommand>
    {
        private readonly IMapper _mapper;
        private readonly IBibliotecaRepository _repositorio;

        public AlterarLivroCommandHandler(
            IMapper mapper,
            IBibliotecaRepository repositorio
        )
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        public async Task<Unit> Handle(AlterarLivroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var livroAlterado = _mapper.Map<Livro>(request);

                await _repositorio.AlterarAsync(livroAlterado);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
