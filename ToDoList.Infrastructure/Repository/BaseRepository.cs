using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Infrastructure.Interface;

namespace ToDoList.Infrastructure.Repository
{
    public abstract class BaseRepository
    {
        protected readonly IDbConnectionFactory dbConnectionFactory;

        public BaseRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

    }
}
