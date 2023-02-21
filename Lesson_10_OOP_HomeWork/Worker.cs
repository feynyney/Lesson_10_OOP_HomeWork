using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassClient;
using ClassConsultant;
using ClassDatabase;

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

        public static void StartWork(Consultant consultant)
        {
            bool isWorking = true;

            Console.WriteLine("\n1 - Begin work\n2 - Exit\n");

            int choice = Convert.ToInt32(Console.ReadLine());

            while(isWorking)
            {
                switch (choice)
                {
                    case 1:
                        isWorking = GetClients(consultant);

                        if(isWorking)
                        {
                            choice = Operations(consultant);
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
                        StartWork(consultant);
                        isWorking = false;
                        break;
                }
            }
        }


        private static int Operations(Consultant consultant)
        {
            int choice;

            Console.WriteLine("\nOperation to do: \n 1 - Read data \n 2 - Change data \n 3 - Back\n");

            choice = Convert.ToInt32(Console.ReadLine());

            int client_id;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nEnter Client`s id to read data: \n");
                    client_id = Convert.ToInt32(Console.ReadLine());
                    consultant.ReadData(client_id);
                    Operations(consultant);
                    break;
                case 2:
                    consultant.ChangeData();
                    break;
                case 3:
                    break;
            }

            return choice;
        }

        private static bool GetClients(Consultant consultant)
        {
            bool isWorkingClientsList = true;

            Console.WriteLine("\nShow clients list? \n 1 - Show \n 2 - Exit\n");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    consultant.ShowClientsList(ClientsDatabase.ReturnClientsFromDb());
                    break;

                case 2:
                    isWorkingClientsList = false;
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
    }
}
