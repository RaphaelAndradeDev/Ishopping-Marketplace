using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Ishopping.Infra.Data.Repositories.Dapper.Commun
{   
    public class Repository : IDisposable
    {
        public IDbConnection IshoppingConnection
        {
            get { return new SqlConnection(ConfigurationManager.ConnectionStrings["IShoppingProject"].ConnectionString); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
    
}
