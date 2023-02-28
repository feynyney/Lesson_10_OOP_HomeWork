using ClassClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerInterface
{
    interface IWorker 
    {
        void ShowClientsList(List<Client> clients)
        {

        }

        void ShowClientsListChanges(List<Client> clients)
        {
           
        }

        void ReadData(int clientId)
        {

        }

        void ChangeData(List<Client> clients)
        {
            
        }
    }
}
