using ClassClient;
using ClassWorker;
using ClassDatabase;
using ClassManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.RegularExpressions;
using WorkerInterface;

namespace ClassConsultant
{
    internal class Consultant : Worker, IWorker
    {

        public Consultant(string Name, string Surname, string Position) : base(Name, Surname, Position)
        {

        }

        public override void ShowClientsList(List<Client> clients)
        {
            clients = ClientsDatabase.ReturnClientsFromDb();

            foreach (var client in clients)
            {
                client.Passport = "#####";
            }

            base.ShowClientsList(clients);
        }

        public override void ShowClientsListChanges(List<Client> clients)
        {
            int indexCount = 0;

            string replace = "#######";

            clients = ClientsDatabase.ReturnClientsFromDb();

            foreach (var client in clients)
            {
                if(client.WhatDataChanged != null)
                {
                    if (client.WhatDataChanged.Contains(client.Passport))
                    {
                        client.WhatDataChanged = Regex.Replace(client.WhatDataChanged, client.Passport, replace);
                    }
                }

                Console.WriteLine($"Id: {indexCount++} {client.GetInformationChanges()}");
            }
        }

        public override void ChangeData(List<Client> clients)
        {
            Console.WriteLine("Only phone number can be changed! Enter new phone number: \n");

            Console.WriteLine("Enter Id to change: ");

            int choiceId = Convert.ToInt32(Console.ReadLine());

            string previousPhone = clients[choiceId].Phone;

            Console.WriteLine("Enter new phone number: ");

            clients[choiceId].Phone = Console.ReadLine();

            clients[choiceId].Phone = EnterWhileStringEmpty(clients[choiceId].Phone);

            clients[choiceId].WhoChanged = "Consultant";

            clients[choiceId].TimeOfChanges = DateTime.Now;

            clients[choiceId].WhatDataChanged = clients[choiceId].WhatDataChanged + "\n" +
                $" Phone {previousPhone} => {clients[choiceId].Phone} " +
                $"Changed: {clients[choiceId].TimeOfChanges} " +
                $"By {clients[choiceId].WhoChanged}\n";

            base.ChangeData(clients);
        }

        public override void ReadData(int clientId)
        {
            int idIndex = 0;

            List<Client> clients = ClientsDatabase.ReturnClientsFromDb();

            clients[clientId].Passport = "######";

            foreach (var client in clients)
            {
                if (idIndex == clientId)
                {
                    Console.WriteLine($"Id: {idIndex} {clients[clientId].GetInformation()}");
                }

                idIndex++;
            }
        }

       
        public static Consultant InitializeConsultant()
        {
            Console.WriteLine("Enter consultant`s Name: ");

            string name = Console.ReadLine();

            name = Worker.EnterWhileStringEmpty(name);

            Console.WriteLine("Enter consultant`s Surname: ");

            string surname = Console.ReadLine();

            surname = Worker.EnterWhileStringEmpty(surname);

            string position = "Consultant";

            Console.WriteLine($"Welcome, {name} {surname} | {position}");

            Consultant new_worker = new Consultant(name, surname, position);

            return new_worker;
        }
    }
}
