namespace api.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Pessoa
    {
        [Key] // determina que o atribulto abaixo "Id" seja definido como chave primaria na criaçã do DB pelo ef_core apartir desse atributo
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Cidade {get; set;}
        public int Idade {get; set;}
        
    }
}