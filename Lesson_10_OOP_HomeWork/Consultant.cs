﻿using ClassClient;
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

        public override void ShowClientsList(List<Client> clients)
        {
            clients = ClientsDatabase.ReturnClientsFromDb();

            foreach (var client in clients)
            {
                client.Passport = "#####";
            }

            base.ShowClientsList(clients);
        }

        public override void ChangeData(List<Client> clients)
        {
            Console.WriteLine("Only phone number can be changed! Enter new phone number: \n");

            Console.WriteLine("Enter Id to change: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new phone number: ");

            clients[choice].Phone = Console.ReadLine();

            base.ChangeData(clients);
        }

        public override void ReadData(int clientId)
        {
            int idIndex = 0;

            List<Client> clients = ClientsDatabase.ReturnClientsFromDb();

            clients[clientId].Passport = "######";

            foreach (var client in clients)
            {
                idIndex++;

                if (idIndex == clientId)
                {
                    Console.WriteLine($"Id: {idIndex} {clients[clientId].GetInformation()}");
                }
            }
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
