using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazLab3.Models
{
    public class Restaurant
    {
        public event Action<string> StatusChanged;
        private readonly object queueLock = new object();
        private int customerCount = 1;

        public void EnterRestaurant(Customer customer)
        {
            lock (queueLock)
            {
                OnStatusChanged($"{customer.Name} entered the restaurant.");

                // Müşterinin yemek yemesini sağla
                customer.Eat();
            }
        }

        public int GetCustomerNumber()
        {
            lock (queueLock)
            {
                return customerCount++;
            }
        }

        private void OnStatusChanged(string status)
        {
            StatusChanged?.Invoke(status);
        }
    }
}
