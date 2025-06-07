using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_LoginForm.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;

        public RepositoryBase()
        {
            _connectionString = "Data Source=WINDOWS\\NGOCTRAM;Initial Catalog=MVVMLoginDb;Integrated Security=True;Trust Server Certificate=True";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection( _connectionString );
        }
    }
}
