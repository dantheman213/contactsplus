using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ContactsPlus.Models;
using System.Diagnostics;

//using SQLite;

namespace ContactsPlus.Source {

    public class Database {
        //private static SQLiteConnection db = null;
        public static List<ContactModel> contacts = null;
        public static int contactCount = 0;

        public static void init() {

            //db = new SQLiteConnection("data.db");
            
            //db.CreateTable<ContactModel>();
            //contacts = db.Table<ContactModel>().ToList<ContactModel>();
            contacts = new List<ContactModel>();
        }

        public static bool addContact(ContactModel contact) {

            try {
                contactCount++;
                contact.ContactId = contactCount;
                //db.Insert(contact);

                contacts.Add(contact);
                contacts = contacts.OrderBy(x => x.FirstName).ToList(); // sort by first name alphabetically

                return true;
            } catch (Exception ex) {
                
            }
            
            return false;
        }

        public static ContactModel getContactById(int contactId) {

            return contacts.FirstOrDefault(x => x.ContactId == contactId);        
        }    

        public static bool updateContact(ContactModel contact) {

            try {
                if (contact.ContactId < 1) {
                    throw new Exception("Invalid Contact!");
                }

                for (int i = 0; i < contacts.Count; i++) {
                    if (contacts[i].ContactId == contact.ContactId) {

                        contacts[i] = contact;
                        return true;
                    }
                }

            } catch (Exception ex) {

                Debug.WriteLine(ex.Message);
            }

            return false;
        }
        
    }
}
