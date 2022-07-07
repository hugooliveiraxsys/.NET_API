
using Models;
using Models.Entities;
using Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Base.Interfaces
{
    public interface IBaseCrudService<Request>
    {
        public Task<int?>CreateAsync(Request request);

        public Task<int?>UpdateAsync(Request request);

        public Task<int?> BulkManualInsert(List<Request> requests);

        public Task BulkInsert(List<Request> requests);

        public Task<PessoaEntity>GetByIdAsync(int id);
         
        public Task<List<string>> GetCpfListAsync(int Limit);

        public Task<IEnumerable<PessoaEntity>> ListAsync(PersonQuery personQuery);

        public Task<IEnumerable<ComboItem>> ComboItem();

        public Task<int>DeleteAsync(int id);
     
    }
}
