using Class_Client;
//using Class_Worker;
//using Class_Consultant;
using System;
using CLients_Database;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClientsDatabase.AddClientToJson();

            ClientsDatabase.ReadJsonDb();

            //Worker.StartWork(Consultant.InitializeConsultant());
        }
    }
}