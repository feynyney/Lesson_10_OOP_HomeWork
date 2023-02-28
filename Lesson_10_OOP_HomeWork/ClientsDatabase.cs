using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ClassClient;
using ClassWorker;

namespace ClassDatabase
{
    internal class ClientsDatabase
    {

        static ClientsDatabase()
        {
            
        }

        public static void ReadJsonDb()
        {
            int indexCount = 0;

            string clientsJsonData = File.ReadAllText(@"..\..\..\ClientsDb.json");

            var clients = JsonSerializer.Deserialize<List<Client>>(clientsJsonData);

            if (clients != null)
            {
                foreach (var client in clients)
                {
                    Console.WriteLine($"Id: {indexCount++} {client.GetInformation()}");
                }
            }
        }

        public static List<Client> ReturnClientsFromDb()
        {
            string clientsJsonData = File.ReadAllText(@"..\..\..\ClientsDb.json");

            var clients = JsonSerializer.Deserialize<List<Client>>(clientsJsonData);

            return clients;
        }

        public static void AddClientToJsonDb()   //Function adds a new client to Json file (Not available for consultant, just a template)
        {
            string clientsJsonData = File.ReadAllText("ClientsDb.json");

            List<Client> clients = new List<Client>();

            Client newClient = ClientCreation();

            newClient.DateOfAdding = DateTime.Now;

            if (clientsJsonData != String.Empty)
            {
                clients = JsonSerializer.Deserialize<List<Client>>(clientsJsonData);

                clients.Add(newClient);

                clientsJsonData = JsonSerializer.Serialize(clients);

                File.WriteAllText("ClientsDb.json", clientsJsonData);
            }

            else
            {
                clients.Add(newClient);

                clientsJsonData = JsonSerializer.Serialize(clients);

                File.WriteAllText("ClientsDb.json", clientsJsonData);
            }
        }

        private static Client ClientCreation()
        {
            Console.WriteLine("Enter client`s name: ");
            
            string name = Console.ReadLine();

            name = Worker.EnterWhileStringEmpty(name);

            Console.WriteLine("Enter client`s surname: ");

            string surname = Console.ReadLine();

            surname = Worker.EnterWhileStringEmpty(surname);

            Console.WriteLine("Enter client`s phone number: ");

            string phone = Console.ReadLine();

            phone = Worker.EnterWhileStringEmpty(phone);

            Console.WriteLine("Enter client`s passport data: ");

            string passport = Console.ReadLine();

            passport = Worker.EnterWhileStringEmpty(passport);

            Client newClient = new Client(name, surname, phone, passport);

            return newClient;
        }

        public static void ApplyJsonDbChanges(List<Client> clients)
        {
            string clientsJsonData = JsonSerializer.Serialize(clients);

            File.WriteAllText("ClientsDb.json", clientsJsonData);
        }
    }
}
