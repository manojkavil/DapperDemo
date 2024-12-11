// See https://aka.ms/new-console-template for more information
using DataLayer;
using Microsoft.Extensions.Configuration;
using Runner;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

IConfigurationRoot config;


Initalize();

//with raw sql
//Insert_contact_should_assign_identity_to_new_entity();

//with Contrib Library
//Get_all_contacts_with_contrib_library();

//with SP
//Get_single_contact_with_stored_procedure(5);

//with Async
Get_single_contact_with_async(7);

Console.ReadLine();
 void Initalize(){

    var a = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory());

    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

    config = builder.Build();


}

void Get_all_contacts()
{
    var repository = CreateRepository();

    var contacts= repository.GetAll();

    contacts.Output();
}

int Insert_contact_should_assign_identity_to_new_entity()
{

    //Arrange
    var repository= CreateRepository();
    var contact = new Contact
    {
        FirstName = "John",
        LastName = "Doe",
        Company = "UST",
        Email = "def@abc.com",
        Title = "SE"


    };

    //Act
    repository.Add(contact);

    //Assert
    Debug.Assert(contact.Id !=0);
    Console.WriteLine("Contact inserted");
    Console.WriteLine($"new id :{contact.Id}");

    return contact.Id;

}


IContactRepository CreateRepository()
{
    var constring = config.GetConnectionString("DefaultConnection");
    return new ContactRepository(constring);
}

///<summary>
/// Contrib Library
///</summary> 
///


void Get_all_contacts_with_contrib_library()
{
    var repository = CreateRepositoryContrib();

    var contacts = repository.GetAll();

    contacts.Output();
}


IContactRepository CreateRepositoryContrib()
{
    var constring = config.GetConnectionString("DefaultConnection");
    return new ContactRepositoryContrib(constring);
}


///<summary>
/// Stored Procedure
///</summary> 
///


void Get_single_contact_with_stored_procedure(int id)
{
    var repository = ContactRepositoryStoredProc();

    var contacts = repository.Find(id);

    contacts.Output();
}


IContactRepository ContactRepositoryStoredProc()
{
    var constring = config.GetConnectionString("DefaultConnection");
    return new ContactRepositoryStoredProc(constring);
}


///<summary>
/// Async operation
///</summary> 
///


async void Get_single_contact_with_async(int id)
{
    var repository = ContactRepositoryAsync();

    var contacts = await repository.FindAsync(id);

    contacts.Output();
}


IContactRepositoryAsync ContactRepositoryAsync()
{
    var constring = config.GetConnectionString("DefaultConnection");
    return new ContactRepositoryAsync(constring);
}