using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YazLab3.Models
{
    public class Customer
    {
        public event Action<string> StatusChanged;

        private readonly Restaurant restaurant;
        public string Name { get; }

        public Customer(string name, Restaurant restaurant)
        {
            Name = name;
            this.restaurant = restaurant;
        }

        public async void JoinRestaurantQueue()
        {
            int customerNumber = restaurant.GetCustomerNumber();
           OnStatusChanged($"{Name} joined the restaurant queue. Customer Number: {customerNumber}");

            // Müşterinin sırasını beklemesini sağla
          await Task.Delay(3000);

            // Restorana giriş yap
            restaurant.EnterRestaurant(this);
        }

        public async void Eat()
        {
            OnStatusChanged($"{Name} is eating...");

            // Simulate eating by sleeping
            await Task.Delay(3000);

            OnStatusChanged($"{Name} finished eating.");
        }

        private void OnStatusChanged(string status)
        {
            StatusChanged?.Invoke(status);
            
        }
    }
}
