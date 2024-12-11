using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ContactRepositoryAsync : IContactRepositoryAsync
    {

        private IDbConnection db;

        public ContactRepositoryAsync(string connString)
        {
            this.db = new SqlConnection(connString);
        }
        public async Task<Contact> FindAsync(int id)
        {
            var item = await db.QueryAsync<Contact>("GetContact", new { Id = id }, commandType: CommandType.StoredProcedure);
            return item.SingleOrDefault();

        }
    }
}
