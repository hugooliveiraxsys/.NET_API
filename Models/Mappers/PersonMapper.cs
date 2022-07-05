
using Mapster;
using Models.Entities;
using Models.Mappers.Base;
using Models.Mappers.Interfaces;
using Models.Requests;

namespace Models.Mappers
{
    public class PersonMapper : BaseMapper<PersonRequest, PessoaEntity>, IPersonMapper
    {
        public PersonMapper()
        {
            TypeAdapterConfig<PersonRequest, PessoaEntity>
                .ForType()
                    .Map(entity => entity.Sexo, request => request.Gender[0])
                .TwoWays()
                    .Map(entity => entity.Nome, request => request.Name)
                    .Map(entity => entity.DataNascimento, request => request.BirthDate);

            TypeAdapterConfig<PessoaEntity, PersonRequest>
                .ForType()
                    .Map(request => request.Gender, entity => entity.Sexo == 'M' ? "Masculino" : "Feminino");
        }
    }
}
