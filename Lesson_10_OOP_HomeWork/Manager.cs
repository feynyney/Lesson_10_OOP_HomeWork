using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassConsultant;
using ClassClient;
using ClassDatabase;
using ClassWorker;
using WorkerInterface;

namespace ClassManager
{
    internal class Manager : Consultant, IWorker
    {
        public Manager(string Name, string Surname, string Position) : base(Name, Surname, Position)
        {

        }

        public static Manager InitializeManager()
        {
            Console.WriteLine("Enter manager`s Name: ");

            string Name = Console.ReadLine();

            Console.WriteLine("Enter manager`s Surname: ");

            string Surname = Console.ReadLine();

            string Position = "Manager";

            Console.WriteLine($"Welcome, {Name} {Surname} | {Position}");

            Manager newManager= new Manager(Name, Surname, Position);

            return newManager;
        }

        public override void ShowClientsList(List<Client> clients)
        {
            int indexCount = 0;

            clients = ClientsDatabase.ReturnClientsFromDb();

            foreach (var client in clients)
            {
                Console.WriteLine($"Id: {indexCount++} {client.GetInformation()}");
            }
        }

        public override void ShowClientsListChanges(List<Client> clients)
        {
            int indexCount = 0;

            foreach (var client in clients)
            {
                Console.WriteLine($"Id: {indexCount++} {client.GetInformationChanges()}");
            }
        }

        public override void ReadData(int clientId)
        {
            List<Client> clients = ClientsDatabase.ReturnClientsFromDb();

            Console.WriteLine(clients[clientId].GetInformation());
        }

        public override void ChangeData(List<Client> clients)
        {
            clients = ClientsDatabase.ReturnClientsFromDb();

            Console.WriteLine("Enter Id to change data: ");

            int choiceId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Change: \n 1 - Name \n 2 - Surname \n 3 - Phone \n 4 - Passport");

            int choiceOperation = Convert.ToInt32(Console.ReadLine());
            string previousName, previousSurname, previousPhone, previousPassport;
            PreviousData(clients, choiceId, out previousName, out previousSurname, out previousPhone, out previousPassport);

            clients[choiceId].WhoChanged = "Manager";

            switch (choiceOperation)
            {
                case 1:
                    clients[choiceId].Name = Console.ReadLine();

                    clients[choiceId].TimeOfChanges = DateTime.Now;

                    clients[choiceId].WhatDataChanged = clients[choiceId].WhatDataChanged + "\n" +
                        $" Name {previousName} => {clients[choiceId].Name} " +
                        $"Changed: {clients[choiceId].TimeOfChanges} " +
                        $"By {clients[choiceId].WhoChanged}\n";

                    break;

                case 2:
                    clients[choiceId].Surname = Console.ReadLine();

                    clients[choiceId].TimeOfChanges = DateTime.Now;

                    clients[choiceId].WhatDataChanged = clients[choiceId].WhatDataChanged + "\n" +
                        $" Surname {previousSurname} => {clients[choiceId].Surname} " +
                        $"Changed: {clients[choiceId].TimeOfChanges}\n" +
                        $"By {clients[choiceId].WhoChanged}\n";


                    break;

                case 3:
                    clients[choiceId].Phone = Console.ReadLine();

                    clients[choiceId].TimeOfChanges = DateTime.Now;

                    clients[choiceId].WhatDataChanged = clients[choiceId].WhatDataChanged + "\n" +
                        $" Phone {previousPhone} => {clients[choiceId].Phone} " +
                        $"Changed: {clients[choiceId].TimeOfChanges}\n" +
                        $"By {clients[choiceId].WhoChanged}\n";

                    clients[choiceId].TimeOfChanges = DateTime.Now;
                    break;

                case 4:
                    clients[choiceId].Passport = Console.ReadLine();

                    clients[choiceId].TimeOfChanges = DateTime.Now;

                    clients[choiceId].WhatDataChanged = clients[choiceId].WhatDataChanged + "\n" +
                        $" Passport {previousPassport} => {clients[choiceId].Passport} " +
                        $"Changed: {clients[choiceId].TimeOfChanges} " +
                        $"By {clients[choiceId].WhoChanged}\n";

                    break;
            }

            ClientsDatabase.ApplyJsonDbChanges(clients);
        }

        public static void PreviousData(List<Client> clients, int choiceId, out string previousName, out string previousSurname, out string previousPhone, out string previousPassport)
        {
            previousName = clients[choiceId].Name;
            previousSurname = clients[choiceId].Surname;
            previousPhone = clients[choiceId].Phone;
            previousPassport = clients[choiceId].Passport;
        }
    }
}
