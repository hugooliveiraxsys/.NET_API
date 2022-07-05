using Dapper;
using Models.Entities.Base;
using System;

namespace Models.Entities
{
    [Table("TB_PESSOA")]
    public class PessoaEntity : BaseEntity
    {
        public string Cpf { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
