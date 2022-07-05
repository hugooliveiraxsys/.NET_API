using Dapper;
using Models;
using Models.Entities;
using Models.Entities.Base;
using Models.Requests;
using Repositories.Base.Interfaces;
using Repositories.Connections.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Z.Dapper.Plus;

namespace Repositories.Base
{
    public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        IDapperConnection _connection;
        public BaseRepository(IDapperConnection connection)
        {
            _connection = connection;
        }

        public async Task<int?> InsertAsync(Entity entity)
        {
            entity.AsCreate<Entity>();
            return await _connection.InsertAsync(entity);
        }

        public async Task<int?> UpdateAsync(Entity entity)
        {
            entity.AsUpdated();
            return await _connection.UpdateAsync(entity);
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _connection.GetAsync<Entity>(id);
        }

        public async Task<IEnumerable<Entity>> ListAsync(PersonQuery personQuery)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ComboItem>> ComboItemAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _connection.DeleteAsync<Entity>(id);
        }

        public Task<int?> BulkInsertManualAsync(List<Entity> entities)
        {
            throw new NotImplementedException();
        }

        public async Task BulkInsertAsync(List<Entity> entities)
        {
            
            //for (int i = 0; i < entities.Count; i++) 
            //{
            //    entities[i].AsCreate();
            //}
            //_connection.BulkInsert(entities);

            List<Entity> insertList = new List<Entity>();

            foreach (Entity entity in entities)
            {
                insertList.Add(entity.AsCreate<Entity>());
            }
             _connection.BulkInsert(insertList);
        }
    }
}
