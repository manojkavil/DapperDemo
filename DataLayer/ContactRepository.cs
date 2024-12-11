using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Transactions;

namespace DataLayer
{
    public class ContactRepository : IContactRepository
    {
        private IDbConnection db;

        public ContactRepository(string connString)
        {
            this.db = new SqlConnection(connString);
        }
        public Contact Add(Contact contact)
        {

            var sql =
                "INSERT INTO Contacts (FirstName, LastName,Email, Company, Title) VALUES (@FirstName,@LastName,@Email,@Company,@Title);" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            using var txtScope = new TransactionScope() ;

            
                var id = this.db.Query<int>(sql, contact).Single();
                contact.Id = id;
            txtScope.Complete();
                return contact;

            
        }

        public Contact Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            return this.db.Query<Contact>("SELECT * FROM [dbo].[Contacts]").ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Contact Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}