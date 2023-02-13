using Class_Client;
using Class_Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Consultant
{
    internal class Consultant : Worker
    {
     
        public Consultant(string Name, string Surname, string Position) : base(Name,Surname,Position)
        {

        }

        public override void ReadData(Client client_to_read)
        {
            client_to_read.Passport = "######";
            base.ReadData(client_to_read);
        }

        public static void ShowClientsList()
        {
            uint index = 0;
            foreach (var client in Client.dbClients)
            {
                client.Passport = "#######";
                Console.WriteLine($"ID: {index++} {client.GetInformation()}");
            }
        }

        public void ChangeData()
        {
            Console.Write("\n*Only Phone number can be changed* \n Enter id to change:\n");

            int client_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nEnter new phone number for {Client.dbClients[client_id].Name} {Client.dbClients[client_id].Surname}\n");

            Client.dbClients[client_id].Phone = Console.ReadLine().ToString();

            while(Client.dbClients[client_id].Phone == String.Empty)
            {
                Console.WriteLine("String cannot be empty!");
                Client.dbClients[client_id].Phone = Console.ReadLine().ToString();
            }
                

            Console.WriteLine("\nNumber has been changed successfuly!\n");
        }

        public static Consultant InitializeConsultant()
        {
            Console.WriteLine("Enter consultant`s Name: ");

            string Name = Console.ReadLine();

            Console.WriteLine("Enter consultant`s Surname: ");

            string Surname = Console.ReadLine();

            string Position = "Consultant";

            Console.WriteLine($"Welcome, {Name} {Surname} | {Position}");

            Consultant new_worker = new Consultant(Name,Surname,Position);

            return new_worker;
        }
    }
}
