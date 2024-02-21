using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YazLab3.Models
{
    public class Till
    {
        public event Action<string> StatusChanged;

        public void HandlePayment()
        {
            for (int i = 0; i < 5; i++)
            {
                OnStatusChanged("Till is handling payment...");
                Thread.Sleep(1200); // Simulating work with a sleep
                OnStatusChanged("Till handled payment.");
            }
        }

        private void OnStatusChanged(string status)
        {
            StatusChanged?.Invoke(status);
        }
    }
}
