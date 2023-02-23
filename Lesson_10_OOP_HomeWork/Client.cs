using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassClient
{
    internal class Client
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Passport { get; set; }

        public DateTime TimeOfChanges { get; set; }

        public string WhatDataChanged { get; set; }

        public string WhoChanged { get; set; }

        public DateTime DateOfAdding { get; set; }

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
            return String.Format("Name:{0,10} |" +
                " Surname:{1,15} |" +
                " Phone:{2,12} |" +
                " Passport:{3,10} |",
                this.Name,
                this.Surname,
                this.Phone,
                this.Passport); 
        }

        public string GetInformationChanges()
        {
            return String.Format("\nData of adding:{0,10}\n |" +
                " What changed:{1,15}\n |" +
                " Who changed:{2,12}\n |\n",
                this.DateOfAdding,
                this.WhatDataChanged,
                this.WhoChanged);
        }
    }
}
