using Models.Entities.Base.Interfaces;
using System;
using Dapper;

namespace Models.Entities.Base

//Minha classe Base

{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [IgnoreUpdate]
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Deletado { get; set; }

        public Entity AsCreate<Entity>() where Entity : BaseEntity
        {
            DataCriacao = DateTime.Now;
            DataAtualizacao = null;
            Deletado = false;
            return (Entity)this;
        }

        public BaseEntity AsUpdated()
        {
            DataAtualizacao = DateTime.Now;
            return this;
        }

        public BaseEntity AsDeleted()
        {
            Deletado=false;
            return this;
        }
    }
}
