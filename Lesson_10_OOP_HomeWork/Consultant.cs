using ClassClient;
using ClassWorker;
using ClassDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ClassConsultant
{
    internal class Consultant : Worker
    {

        public Consultant(string Name, string Surname, string Position) : base(Name, Surname, Position)
        {

        }

        public static void ShowClientsList()
        {
            int indexCount = 0;

            List<Client> clients = ClientsDatabase.ReturnClientsFromDb();

            foreach (var client in clients)
            {
                client.Passport = "########";
                Console.WriteLine($"Id: {indexCount++} {client.GetInformation()}");
            }
        }

        public void ChangeData()
        {
            List<Client> clients = ClientsDatabase.ReturnClientsFromDb();

            Console.WriteLine("Choose Id to change data: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Only phone number can be changed! Enter new phone number: ");

            clients[choice].Phone = Console.ReadLine();

            ApplyJsonDbChanges(clients);
        }

        private static void ApplyJsonDbChanges(List<Client> clients)
        {
            string clientsJsonData = JsonSerializer.Serialize(clients);

            File.WriteAllText("ClientsDb.json", clientsJsonData);
        }

        public static Consultant InitializeConsultant()
        {
            Console.WriteLine("Enter consultant`s Name: ");

            string Name = Console.ReadLine();

            Console.WriteLine("Enter consultant`s Surname: ");

            string Surname = Console.ReadLine();

            string Position = "Consultant";

            Console.WriteLine($"Welcome, {Name} {Surname} | {Position}");

            Consultant new_worker = new Consultant(Name, Surname, Position);

            return new_worker;
        }
    }
}
