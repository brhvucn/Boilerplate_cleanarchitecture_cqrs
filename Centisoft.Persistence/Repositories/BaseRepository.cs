using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Persistence.Repositories
{
    public class BaseRepository
    {
        protected DataContext dataContext;
        protected string tableName;
        public BaseRepository(string tableName, DataContext dataContext)
        {
            Ensure.That(tableName, nameof(tableName)).IsNotNullOrEmpty();
            Ensure.That(dataContext, nameof(dataContext)).IsNotNull();
            this.tableName = tableName;
            this.dataContext = dataContext;
        }
    }
}
