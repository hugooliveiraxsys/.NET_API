using Models;
using Models.Entities;
using Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Base.Interfaces
{
    public interface IBaseRepository<Entity>
    {
        public Task<int?>InsertAsync(Entity entity);

        public Task<int?> BulkInsertManualAsync(List<Entity> entities);

        public Task BulkInsertAsync(List<Entity> entities);

        public Task<int?>UpdateAsync(Entity entity);

        public Task<Entity>GetByIdAsync(int id);

        public Task<Entity> GetByCpfAsync(string cpf);

        public Task<List<string>> GetCpfListAsync(int Limit);

        public Task<IEnumerable<Entity>>ListAsync(PersonQuery personQuery);

        public Task<IEnumerable<ComboItem>>ComboItemAsync();

        public Task<int> DeleteAsync(int id);       
    }
}
