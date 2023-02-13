using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Client
{
    internal class Client
    {

        public static List<Client> dbClients;

        private static uint index;

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Passport { get; set; }

        static Client()
        {
            dbClients = new List<Client>();

            index = 0;
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

        public static void ClientsList()
        {
            Client.dbClients = new List<Client>()
            {
                new Client("Dima","Mak","0985257895","AB584554"),
                new Client("Olha","Kolova","067584554","OK123123"),
                new Client("Oleg","Ivanchenko","099554414","KJ13213213"),
                new Client("Andrii","Ostapov","067484546","LI12313213"),
                new Client("Alex","Baturin","033456775","CA1231233"),
                new Client("Alina","Matveeva","025484564","EQ12315512")};
        }
    }
}
