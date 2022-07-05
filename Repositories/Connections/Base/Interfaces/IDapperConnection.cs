using Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Connections.Base
{
    public interface IDapperConnection : IDbConnection
    {
        public IDbConnection DapperConnection { get; set; }

        Task BulkInsert(List<BaseEntity> entities);
    }
}
