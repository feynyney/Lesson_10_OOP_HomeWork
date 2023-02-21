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

        public static Consultant InitializeManager()
        {
            Console.WriteLine("Enter manager`s Name: ");

            string Name = Console.ReadLine();

            Console.WriteLine("Enter manager`s Surname: ");

            string Surname = Console.ReadLine();

            string Position = "Manager";

            Console.WriteLine($"Welcome, {Name} {Surname} | {Position}");

            Manager new_manager= new Manager(Name, Surname, Position);

            return new_manager;
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

        public override void ChangeData(List<Client> clients)
        {
            clients = ClientsDatabase.ReturnClientsFromDb();

            Console.WriteLine("Enter Id to change data: ");

            int choiceId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Change: \n 1 - Name \n 2 - Surname \n 3 - Phone \n 4 - Passport");

            int choiceOperation = Convert.ToInt32(Console.ReadLine());

            switch(choiceOperation)
            {
                case 1:
                    clients[choiceId].Name = Console.ReadLine();
                    break;

                case 2:
                    clients[choiceId].Surname = Console.ReadLine();
                    break;

                case 3:
                    clients[choiceId].Phone = Console.ReadLine();
                    break;

                case 4:
                    clients[choiceId].Passport = Console.ReadLine();
                    break;
            }

            ClientsDatabase.ApplyJsonDbChanges(clients);
        }
    }
}
