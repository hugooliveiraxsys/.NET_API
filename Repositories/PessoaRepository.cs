using Dapper;
using Models;
using Models.Entities;
using Models.Requests;
using Repositories.Base;
using Repositories.Connections.Interfaces;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PessoaRepository : BaseRepository<PessoaEntity>, IPessoaRepository
    {
        private readonly IDbConnection _connection;

        public PessoaRepository(IEstagTestConnection connection) : base(connection)
        {
            _connection = connection;
        }

        //Criar um metodo que retorna um usuario a partir da lista de cpfs

        public new async Task<List<string>> GetCpfListAsync(int Limit)
        {
            StringBuilder query = new StringBuilder();  
            query.Append($"SELECT TOP {Limit} CPF FROM TB_PESSOA");

            IEnumerable<string> cpfs = await _connection.QueryAsync<string>(query.ToString());
            return cpfs.ToList();
        }

        public async Task<IEnumerable<PessoaEntity>> ListAsync(PersonQuery personQuery)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"SELECT TOP {personQuery.Limit} FROM TB_PESSOA");

            IEnumerable<PessoaEntity> pessoaEntities = await _connection.QueryAsync<PessoaEntity>(query.ToString());
            return pessoaEntities;
        }

        public async Task<IEnumerable<ComboItem>>ComboItemAsync()
        {
            StringBuilder query = new StringBuilder();

            query.Append("SELECT ID, NOME AS Text FROM [dbo].[TB_PESSOA]");

            IEnumerable<ComboItem> comboItem = await _connection.QueryAsync<ComboItem>(query.ToString());

            return comboItem;
        }

        public async Task<int?> BulkInsertManualAsync(List<PessoaEntity> pessoasEntities)
        {
            bool firstime = true;
            StringBuilder query = new StringBuilder();

            query.Append(@"
                INSERT INTO [dbo].[TB_PESSOA]
                (
                    [CPF],
                    [NOME],
                    [DataNascimento],
                    [SEXO]
                )"
            );
            query.AppendLine("VALUES");

            foreach (PessoaEntity pessoaEntity in pessoasEntities)
            {
                pessoaEntity.AsCreate<PessoaEntity>();
                

                query.AppendLine(firstime ? string.Empty : ",");
                firstime = false;

                query.AppendLine($"('{pessoaEntity.Cpf}',");
                query.AppendLine($"'{pessoaEntity.Nome}',");

                string birthDate = pessoaEntity.DataNascimento?.ToString("yyyy-MM-dd");

                query.AppendLine(!string.IsNullOrWhiteSpace(birthDate) ? $"'{birthDate}'," : "NULL");
                query.AppendLine($"'{pessoaEntity.Sexo}'");

                query.AppendLine($")");

                //query.AppendLine("SELECT CAST(SCOPE_IDENTITY() AS INT)");
            }

            IEnumerable<int> results = await _connection.QueryAsync<int>(query.ToString());
            return results.FirstOrDefault();
        }
    }
}
