﻿using ClassWorker;
using ClassConsultant;
using ClassManager;
using System;
using ClassDatabase;
using ClassClient;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker.StartWork(Consultant.InitializeConsultant());

            //Manager manager1 = new Manager("Dima", "Mak", "Manager");

            //manager1.ShowClientsList();


           
        }
    }
}