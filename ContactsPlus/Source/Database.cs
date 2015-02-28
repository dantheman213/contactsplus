using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ContactsPlus.Models;

//using SQLite;

namespace ContactsPlus.Source {

    public class Database {
        //private static SQLiteConnection db = null;
        public static List<ContactModel> contacts = null;

        public static void init() {

            //db = new SQLiteConnection("data.db");
            
            //db.CreateTable<ContactModel>();
            //contacts = db.Table<ContactModel>().ToList<ContactModel>();
            contacts = new List<ContactModel>();
        }

        public static bool addContact(ContactModel contact) {

            try {

                //db.Insert(contact);

                contacts.Add(contact);
                contacts = contacts.OrderBy(x => x.FirstName).ToList(); // sort by first name alphabetically

                return true;
            } catch (Exception ex) {
                
            }
            
            return false;
        }
        
    }
}
