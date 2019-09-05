using ContactsManager.Models;
using ContactsManager;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace ContactsManager.Helpers
{
    class AccountDB
    {
        private SQLiteConnection _SQLiteConnection;
        public AccountDB()
        {
            _SQLiteConnection = DependencyService.Get<ISQLiteInterface>().GetSQLiteConnection();
         

            _SQLiteConnection.CreateTable<Account>();
            _SQLiteConnection.CreateTable<Contact>();

        }
      
       
        public void DeleteAccount(Account account)
        {
            List<Contact> contacts = _SQLiteConnection.Table<Contact>().Where(x => x.AccountId == account.Id).ToList();
            foreach(var contct in contacts)
            {
                DeleteContact(contct);
            }
            _SQLiteConnection.Delete<Account>(account.Id);
        }
        public bool AddAccount(Account user)
        {

            var data = _SQLiteConnection.Table<Account>();
            var d1 = data.Where(x => x.Email == user.Email).FirstOrDefault();
            if (d1 == null)
            {
                _SQLiteConnection.Insert(user);
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Account> ShowAll()
        {

            return _SQLiteConnection.Table<Account>().Where(v => v.Id > -1).ToList();
        }
      
        public bool LoginValidate(string email, string password)
        {

            var data = _SQLiteConnection.Table<Account>();
            var d1 = data.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (d1 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddContact(Contact contact, Account account)
        {

            var data = _SQLiteConnection.Table<Contact>();
            contact.AccountId = account.Id;
             _SQLiteConnection.Insert(contact);
        }   

        public void DeleteContact(Contact contact)
        {

            _SQLiteConnection.Delete<Contact>(contact.Id);
        }
        public ObservableCollection<Contact> FindContact(Account account)
        {

            var data = _SQLiteConnection.Table<Contact>();
            List<Contact> list = (from values in data
                                  where values.AccountId
                                  == account.Id
                                  select values).ToList();
            return new ObservableCollection<Contact>(list as List<Contact>);
        }
        public Account FindAccount(string email)
        {

            var data = _SQLiteConnection.Table<Account>();
            var d1 = (from values in data
                      where values.Email == email
                      select values).Single();
            if (d1 != null)
            {
                return d1;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateContact(Contact contact)
        {

            var data = _SQLiteConnection.Table<Contact>();
            var d1 = (from values in data
                      where values.Id == contact.Id
                      select values
                      ).Single();

            d1.FirstName = contact.FirstName;
            d1.LastName = contact.LastName;
            d1.PhoneNumber = contact.PhoneNumber;
            d1.Photo = contact.Photo;
            d1.Adress = contact.Adress;
            d1.Relationship = contact.Relationship;
                _SQLiteConnection.Update(d1);
                return true;     
        }
    }
}
