using Models.Entities.Base;
using Repositories.Connections.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Repositories.Connections
{
    public class EstagTestConnection : DbConnection, IEstagTestConnection
    {
        public IDbConnection DapperConnection { get; set; }

        public EstagTestConnection(string stringConnection)
        {
            DapperConnection = new SqlConnection(stringConnection);
        }

        public override string ConnectionString { get; set; }

        public override string Database { get; }

        public override string DataSource { get; }

        public override string ServerVersion { get; }

        public override ConnectionState State => DapperConnection.State;


        public override void ChangeDatabase(string databaseName)
        {
            DapperConnection.ChangeDatabase(databaseName);
        }

        public override void Close()
        {
            DapperConnection.Close();
        }

        public override void Open()
        {
            DapperConnection.Open();
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return (DbTransaction)DapperConnection.BeginTransaction();
        }

        protected override DbCommand CreateDbCommand()
        {
            return (DbCommand)DapperConnection.CreateCommand();
        }

        public Task BulkInsert(List<BaseEntity> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}
