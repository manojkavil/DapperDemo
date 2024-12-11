﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace DataLayer
{
    public class ContactRepositoryContrib : IContactRepository
    {
        private IDbConnection db;

        public ContactRepositoryContrib(string connString)
        {
            this.db = new SqlConnection(connString);
        }
        public Contact Add(Contact contact)
        {
            var id= this.db.Insert(contact);
            contact.Id=(int)id;
            return contact;

        }

        public Contact Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            return db.GetAll<Contact>().ToList();
        }

        public void Remove(int id)
        {
            db.Delete(new Contact { Id = id });
        }

        public Contact Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
