using Models;
using Models.Entities;
using Models.Mappers.Interfaces;
using Models.Requests;
using Repositories.Interfaces;
using Services.Base.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPersonMapper _personMapper; // Carinha que vai fazer mapeamento

        public PersonService(IPessoaRepository pessoaRepository, IPersonMapper personMapper)
        {
            _pessoaRepository = pessoaRepository;
            _personMapper = personMapper;
        }

        public async Task<int?>CreateAsync(PersonRequest request)
        {
            
            if (request.Name.Length > 50)
            {
                throw new Exception("Campo nome não pode ser maior que 50 caracteres");
            }
            PessoaEntity entity = _personMapper.ToEntity(request); // Mapeamento :)
            return await _pessoaRepository.InsertAsync(entity);
        }

        public async Task<int?> BulkManualInsert(List<PersonRequest> requests)
        {
            List<PessoaEntity> entities = new List<PessoaEntity>();

            foreach (PersonRequest request in requests)
            {
                if (request.Name.Length > 50)
                {
                    throw new Exception("Campo nome não pode ser maior que 50 caracteres");
                }
                
                entities.Add(_personMapper.ToEntity(request));
            }
            return await _pessoaRepository.BulkInsertManualAsync(entities);
        }

        public async Task BulkInsert(List<PersonRequest> requests)
        {
            List<PessoaEntity> entities = new List<PessoaEntity>();

            foreach (PersonRequest request in requests)
            {
                if (request.Name.Length > 50)
                {
                    throw new Exception("Campo nome não pode ser maior que 50 caracteres");
                }

                entities.Add(_personMapper.ToEntity(request));
            }
            await _pessoaRepository.BulkInsertAsync(entities);
        }

        public async Task<int?>UpdateAsync(PersonRequest request)
        {
            PessoaEntity entity = new PessoaEntity();
            entity = _personMapper.ToEntity(request);
            return (int)await _pessoaRepository.UpdateAsync(entity);
        }

        public async Task<PessoaEntity>GetByIdAsync(int id)
        {
            return await _pessoaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PessoaEntity>> ListAsync(PersonQuery personQuery)
        {
            return await _pessoaRepository.ListAsync(personQuery);
        }

        public async Task<IEnumerable<ComboItem>> ComboItem()
        {
            return await _pessoaRepository.ComboItemAsync();
        }

        public async Task<int>DeleteAsync(int id) 
        {
            return await _pessoaRepository.DeleteAsync(id);
        }
    }
}
