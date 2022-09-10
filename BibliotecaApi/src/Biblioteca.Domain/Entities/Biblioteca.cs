using Newtonsoft.Json;

namespace Biblioteca.Domain.Entities
{
    public class Livros
    {
        [JsonIgnore()]
        public int Id { get; set; }

        [JsonProperty("nomeDoLivro")]
        public string NomeDoLivro { get; set; }

        [JsonProperty("nomeDoAutor")]
        public string NomeDoAutor { get; set; }

        [JsonProperty("numeroDePaginas")]
        public int NumeroDePaginas { get; set; }
    }
}