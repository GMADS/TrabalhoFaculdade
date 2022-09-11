using AutoMapper;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interface.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Command.Post
{
    public class AddLivroCommandHandler : IRequestHandler<AddLivroCommand>
    {
        private readonly IMapper _mapper;
        private readonly IBibliotecaRepository _repositorio;

        public AddLivroCommandHandler(
            IMapper mapper,
            IBibliotecaRepository repositorio
        )
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        public async Task<Unit> Handle(AddLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = _mapper.Map<Livro>(request);

            await _repositorio.AdicionarAsync(livro);

            return Unit.Value;
        }
    }
}
