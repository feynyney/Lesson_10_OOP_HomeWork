using Class_Client;
using Class_Worker;
using Class_Consultant;
using System;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client.ClientsList();

            Worker.StartWork(Consultant.InitializeConsultant());
        }
    }
}