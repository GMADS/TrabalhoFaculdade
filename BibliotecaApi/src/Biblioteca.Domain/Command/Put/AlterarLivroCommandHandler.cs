using AutoMapper;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interface.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Command.Put
{
    public class AlterarLivroCommandHandler : IRequestHandler<AlterarLivroCommand, AlterarLivroCommandResponse>
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

        public async Task<AlterarLivroCommandResponse> Handle(AlterarLivroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await ChecarSeLivroExistiAsync(request.Id))
                {
                    var novoLivro = _mapper.Map<Livro>(request);

                    await _repositorio.AlterarAsync(novoLivro);

                    return new AlterarLivroCommandResponse(true);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool>ChecarSeLivroExistiAsync(int id)
        {
            var livro = await _repositorio.ObterPorIdAsync(id);

            if (livro == null)
                return false;

            return true;
        }
    }
}
