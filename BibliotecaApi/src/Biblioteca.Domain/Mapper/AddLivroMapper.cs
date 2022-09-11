using AutoMapper;
using Biblioteca.Domain.Command.Post;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Mapper
{
    public class AddLivroMapper : Profile
    {
        public AddLivroMapper()
        {
            CreateMap<AddLivroCommand, Livros>()
                .ForMember(x => x.NomeDoLivro, opt => opt.MapFrom(src => src.NomeDoLivro))
                .ForMember(x => x.NomeDoAutor, opt => opt.MapFrom(src => src.NomeDoAutor))
                .ForMember(x => x.NumeroDePaginas, opt => opt.MapFrom(src => src.NumeroDePaginas));

        }
    }
}
