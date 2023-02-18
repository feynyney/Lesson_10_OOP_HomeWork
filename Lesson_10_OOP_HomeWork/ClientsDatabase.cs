using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ClassClient;
//using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClassDatabase
{
    internal class ClientsDatabase
    {
        public static List<Client> dbClients;

        static ClientsDatabase()
        {
            dbClients = new List<Client>();
        }

        public static void ReadJsonDb()
        {
            int indexCount = 0;

            string clientsJsonData = File.ReadAllText("ClientsDb.json");

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

            string clientsJsonData = File.ReadAllText("ClientsDb.json");

            var clients = JsonSerializer.Deserialize<List<Client>>(clientsJsonData);

            return clients;
        }

        //private static List<Client> GetReturnedClients()
        //{
        //    List<Client> clients = new List<Client>();

        //    clients = ClientsDatabase.ReturnClientsFromDb();
        //    return clients;
        //}

        public static void AddClientToJsonDb()
        {
            string clientsJsonData = File.ReadAllText("ClientsDb.json");

            List<Client> clients = new List<Client>();

            Client newClient = ClientCreation();

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

            Console.WriteLine("Enter client`s surname: ");

            string surname = Console.ReadLine();

            Console.WriteLine("Enter client`s phone number: ");

            string phone = Console.ReadLine();

            Console.WriteLine("Enter client`s passport data: ");

            string passport = Console.ReadLine();

            Client newClient = new Client(name, surname, phone, passport);

            return newClient;
        }

        //public static async void JsonDataBase(List<Client> dbClients)
        //{
        //    string jsonDb = JsonConvert.SerializeObject(dbClients);

        //    System.IO.File.AppendAllText("user.json", jsonDb + "\n");
        //}

        //public static void ReadJson()
        //{
        //    string filename = "user.json";
        //    string read = JsonSerializer.Serialize(filename);
        //    using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        //    {
        //        File.WriteAllText("user.json", read);
        //    }
        //}
    }
}
