using ClassWorker;
using ClassConsultant;
using ClassManager;
using System;
using ClassDatabase;
using ClassClient;
using WorkerInterface;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ClientsDatabase.AddClientToJsonDb();

            Worker.StartWork(Worker.InitializeWorker());
        }
    }
}