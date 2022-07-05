using Models.Entities;
using Models.Mappers.Base.Interfaces;
using Models.Requests;

namespace Models.Mappers.Interfaces
{
    public interface IPersonMapper : IBaseMapper<PersonRequest, PessoaEntity>
    {

    }
}
