using AutoMapper;
using Biblioteca.Domain.Command.Post;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Query.GetById;

namespace Biblioteca.Domain.Mapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<AddLivroCommand, Livros>()
                .ForMember(x => x.NomeDoLivro, opt => opt.MapFrom(src => src.NomeDoLivro))
                .ForMember(x => x.NomeDoAutor, opt => opt.MapFrom(src => src.NomeDoAutor))
                .ForMember(x => x.NumeroDePaginas, opt => opt.MapFrom(src => src.NumeroDePaginas));

            CreateMap<GetLivroByIdQueryResponse, Livros>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.NomeDoLivro, opt => opt.MapFrom(src => src.NomeDoLivro))
                .ForMember(x => x.NomeDoAutor, opt => opt.MapFrom(src => src.NomeDoAutor))
                .ForMember(x => x.NumeroDePaginas, opt => opt.MapFrom(src => src.NumeroDePaginas));
        }
    }
}
