using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ContactsPlus.Models;
using System.Diagnostics;


namespace ContactsPlus.Source {

    public class Database {
        public static List<ContactModel> contacts = null;
        public static int contactCount = 0;

        public static void init() {

            contacts = new List<ContactModel>();
        }

        public static bool addContact(ContactModel contact) {

            try {
                contactCount++;
                contact.ContactId = contactCount;

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
