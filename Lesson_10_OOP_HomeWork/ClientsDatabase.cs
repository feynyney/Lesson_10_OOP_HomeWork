using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Class_Client;
//using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CLients_Database
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
            string clientsJsonData = File.ReadAllText("ClientsDb.json");

            var clients = JsonSerializer.Deserialize<List<Client>>(clientsJsonData);

            //Console.WriteLine("Choose id: ");

            //int choice = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine(clients[choice].Name);

            //clients[choice].Name = Console.ReadLine();

            //Console.WriteLine(clients[choice].Name);

            if (clients != null)
            {
                foreach (var client in clients)
                {
                    Console.WriteLine($"{client.Name} {client.Surname}");
                }
            }


        }

        public static void AddClientToJson()
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
