﻿namespace DataLayer
{
    public interface IContactRepository
    {
        Contact Find(int id);
        List<Contact> GetAll();
        Contact Add(Contact contact);
        Contact Update(Contact contact);
        void Remove(int id);


    }
}