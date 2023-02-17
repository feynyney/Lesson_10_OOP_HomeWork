//using Class_Client;
//using Class_Consultant;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Class_Worker
//{
//    internal abstract class Worker
//    {
//        protected string position;

//        public string Name { get; set; }

//        public string Surname { get; set; }

//        public string Position { get { return this.position; } }

//        public Worker(string name, string surname, string position)
//        {
//            Name = name;
//            Surname = surname;
//            this.position = position;
//        }

//        public static void StartWork(Consultant consultant)
//        {
//            ConsultantWorkLogicLoop(consultant);
//        }

//        private static void ConsultantWorkLogicLoop(Consultant consultant)
//        {
//            bool flag = true;

//            while (flag)
//            {
//                flag = ConsultantWorkLogic(consultant);
//            }
//        }

//        private static bool ConsultantWorkLogic(Consultant consultant)
//        {
//            bool loop_flag = true;

//            bool clients_list_show_flag;

//            Console.WriteLine("\n1 - Begin work\n2 - Exit\n");

//            int choice = Convert.ToInt32(Console.ReadLine());

//            switch (choice)
//            {
//                case 1:
//                    clients_list_show_flag = GetClients();

//                    if(clients_list_show_flag)
//                    {
//                        choice = Operations(consultant);
//                        break;
//                    }
//                    else
//                    {
//                        loop_flag = false;
//                    }
//                    break;
//                case 2: loop_flag = false;
//                        break;
//            }
//            return loop_flag;
//        }

//        private static int Operations(Consultant consultant)
//        {
//            int choice;
//            Console.WriteLine("\nOperation to do: \n 1 - Read data \n 2 - Change data \n 3 - Back\n");

//            choice = Convert.ToInt32(Console.ReadLine());

//            int client_id;

//            switch (choice)
//            {
//                case 1:
//                    Console.WriteLine("\nEnter Client`s id to read data: \n");
//                    client_id = Convert.ToInt32(Console.ReadLine());
//                    consultant.ReadData(Client.dbClients[client_id]);
//                    break;
//                case 2:
//                    consultant.ChangeData();
//                    break;
//                case 3:
//                    break;
//            }

//            return choice;
//        }

//        private static bool GetClients()
//        {
//            bool flag = true;

//            Console.WriteLine("\nShow clients list? \n 1 - Show \n 2 - Exit\n");

//            int choice = Convert.ToInt32(Console.ReadLine());

//            switch (choice)
//            {
//                case 1:
//                    Consultant.ShowClientsList();
//                    break;

//                case 2: flag = false;
//                    break;
//            }
//            return flag;
//        }

//        public virtual void ReadData(Client person_to_read_data)
//        {
//            Console.WriteLine(person_to_read_data.GetInformation());
//        }
//    }
//}
