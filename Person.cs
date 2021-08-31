using System.Collections.Generic;

namespace BankConsole
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public Address Address { get; set; }

        public string AddressWithName
        {
            get
            {
                return $"{FullName}\n{Address.FullAddress}";
            }
        }
    }

}