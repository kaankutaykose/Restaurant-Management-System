using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YazLab3.Models
{
    public class Waiter
    {
        public event Action<string> StatusChanged;

        public void Serve()
        {
            for (int i = 0; i < 5; i++)
            {
                OnStatusChanged("Waiter is serving...");
                Thread.Sleep(1000); // Simulating work with a sleep
                OnStatusChanged("Waiter Served.");
            }
        }

        private void OnStatusChanged(string status)
        {
            StatusChanged?.Invoke(status);
        }
    }
}
