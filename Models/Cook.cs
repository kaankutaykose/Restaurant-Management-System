using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YazLab3.Models
{
    public class Cook
    {
        public event Action<string> StatusChanged;

        public void CookMeal()
        {
            for (int i = 0; i < 5; i++)
            {
                OnStatusChanged("Cook is cooking...");
                Thread.Sleep(1500); // Simulating work with a sleep
                OnStatusChanged("Cook cooked.");
            }
        }

        private void OnStatusChanged(string status)
        {
            StatusChanged?.Invoke(status);
        }
    }
}
