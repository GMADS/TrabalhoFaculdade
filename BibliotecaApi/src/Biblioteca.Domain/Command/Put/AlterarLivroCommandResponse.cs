namespace Biblioteca.Domain.Command.Put
{
    public class AlterarLivroCommandResponse
    {
        public AlterarLivroCommandResponse(bool alterado) =>
            Alterado = alterado;

        public bool Alterado { get; set; }
    }
}
