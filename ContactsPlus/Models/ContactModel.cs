using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsPlus.Models {

    public class ContactModel {

        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PrimaryNumber { get; set; }

        public string SecondaryNumber { get; set; }


        public string FullName { 
            get {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }
      
    }

    
}
