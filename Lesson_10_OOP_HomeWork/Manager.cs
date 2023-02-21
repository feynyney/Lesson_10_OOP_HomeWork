using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassConsultant;
using ClassClient;
using ClassDatabase;

namespace ClassManager
{
    internal class Manager : Consultant
    {
        public Manager(string Name, string Surname, string Position) : base(Name, Surname, Position)
        {

        }

        //public override void ShowClientsList()
        //{
        //    int indexCount = 0;

        //    List<Client> clients = ClientsDatabase.ReturnClientsFromDb();

        //    foreach (var client in clients)
        //    {
        //        Console.WriteLine($"Id: {indexCount++} {client.GetInformation()}");
        //    }
        //}
    }
}
