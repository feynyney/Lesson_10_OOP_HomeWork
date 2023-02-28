using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassClient;
using ClassConsultant;
using ClassDatabase;
using ClassManager;
using WorkerInterface;

namespace ClassWorker
{
    internal abstract class Worker
    {
        protected private string _position;

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Position { get { return this._position; } }

        public Worker(string name, string surname, string position)
        {
            Name = name;
            Surname = surname;
            this._position = position;
        }

        public static void StartWork(IWorker newWorker)
        {
            bool isWorking = true;

            Console.WriteLine("\n1 - Begin work\n2 - Exit\n");

            int choice = Convert.ToInt32(Console.ReadLine());

            while(isWorking)
            {
                switch (choice)
                {
                    case 1:
                        isWorking = GetClients(newWorker);

                        if(isWorking)
                        {
                            Operations(newWorker);
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 2:
                        isWorking = false;
                        break;

                    case 3:
                        StartWork(newWorker);
                        isWorking = false;
                        break;
                }
            }
        }


        private static void Operations(IWorker newWorker)
        {
            int choice;

            List<Client> clients = ClientsDatabase.ReturnClientsFromDb();

            if(newWorker is Consultant)
            {
                Console.WriteLine("\nOperation to do: \n 1 - Read data \n 2 - Change data \n 3 - Back\n");
            }
            
            if(newWorker is Manager)
            {
                Console.WriteLine("\nOperation to do: \n 1 - Read data \n 2 - Change data \n 3 - Back\n 4 - Add new client \n");
            }

            choice = Convert.ToInt32(Console.ReadLine());

            int client_id;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nEnter Client`s id to read data: \n");
                    client_id = Convert.ToInt32(Console.ReadLine());
                    newWorker.ReadData(client_id);
                    break;
                case 2:
                    newWorker.ChangeData(clients);
                    break;
                case 3:
                    break;
                case 4:
                    if(newWorker is Manager)
                    {
                        newWorker.AddClientToJsonDb();
                        Console.WriteLine("New client has been added!");
                    }
                    else
                    {
                        break;
                    }
                    break;
            }
        }

        private static bool GetClients(IWorker newWorker)
        {
            bool isWorkingClientsList = true;

            Console.WriteLine("\nShow clients list? \n 1 - Show \n 2 - Operations \n 3 - Exit\n 4 - Show changes");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    newWorker.ShowClientsList(ClientsDatabase.ReturnClientsFromDb());
                    break;

                case 2:
                    break;

                case 3:
                    isWorkingClientsList = false;
                    break;

                case 4:
                    newWorker.ShowClientsListChanges(ClientsDatabase.ReturnClientsFromDb());
                    break;
            }

            return isWorkingClientsList;
        }

        public virtual void ReadData(int clientId)
        {
            List<Client> clients = ClientsDatabase.ReturnClientsFromDb();

            Console.WriteLine(clients[clientId].GetInformation());
        }

        public virtual void ShowClientsList(List<Client> clients)
        {
            int indexCount = 0;

            foreach (var client in clients)
            {
                Console.WriteLine($"Id: {indexCount++} {client.GetInformation()}");
            }
        }

        public virtual void ShowClientsListChanges(List<Client> clients)
        {
            int indexCount = 0;

            foreach (var client in clients)
            {
                Console.WriteLine($"Id: {indexCount++} {client.GetInformationChanges()}");
            }
        }

        public virtual void ChangeData(List<Client> clients)
        {
            ClientsDatabase.ApplyJsonDbChanges(clients);
        }

        public static IWorker InitializeWorker()
        {
            IWorker newWorker = null;

            Console.WriteLine("Enter your position Manager/Consultant?: ");

            string position = Console.ReadLine();

            switch(position)
            {
                case "Consultant":
                    newWorker = Consultant.InitializeConsultant();
                    break;

                case "consultant":
                    newWorker = Consultant.InitializeConsultant();
                    break;

                case "Manager":
                    newWorker = Manager.InitializeManager();
                    break;

                case "manager":
                    newWorker = Manager.InitializeManager();
                    break;
            }

            return newWorker;
        }
    }
}
