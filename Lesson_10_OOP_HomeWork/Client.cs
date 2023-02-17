using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Client
{
    internal class Client
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Passport { get; set; }

        static Client()
        {
        }

        public Client(string Name, string Surname, string Phone, string Passport)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Phone = Phone;
            this.Passport = Passport;
        }


        public string GetInformation()
        {
            return String.Format("Name:{0,10} | Surname:{1,15} | Phone:{2,12} | Passport:{3,10}",
                this.Name,
                this.Surname,
                this.Phone,
                this.Passport); 
        }
    }
}
