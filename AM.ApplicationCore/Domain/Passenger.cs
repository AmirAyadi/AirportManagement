using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TelNumber { get; set; }
        public string EmailAddress { get; set; }
        ICollection<Flight> Flights { get; set; }

        //Polymorphe par signature .
        // Two methods with the same name but different params 
        public bool CheckProfile(string firstName, string lastName)
        {
            return FirstName.Equals(firstName) && LastName.Equals(lastName);
        }
        public bool CheckProfile(string firstName, string lastName,string email)
        {
           // return FirstName.Equals(firstName) && LastName.Equals(lastName) && EmailAddress.Equals(email);
            return CheckProfile(firstName,lastName) && EmailAddress.Equals(email);
        }

        public bool Login(string? firstName, string lastName, string email=null)
        {
            if(email != null) {return  CheckProfile(firstName, lastName, email); }

            else { return CheckProfile(firstName, lastName); }
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am passenger");
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
