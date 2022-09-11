using MediatR;

namespace Biblioteca.Domain.Query.GetById
{
    public  class GetLivroByIdQuery : IRequest<GetLivroByIdQueryResponse>
    {
        public GetLivroByIdQuery(int id) =>
            Id = id;

        public int Id { get; set; }
    }
}
