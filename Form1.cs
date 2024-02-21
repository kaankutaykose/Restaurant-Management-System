using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazLab3.Models;

namespace YazLab3
{
    public partial class Form1 : Form
    {
        private Waiter waiter;
        private Cook cook;
       
        private Till till;
        private Restaurant restaurant;

        public Form1()
        {
            InitializeComponent();

            waiter = new Waiter();
            cook = new Cook();
            //restaurant = new Restaurant();
            till = new Till();

            // Subscribe to the StatusChanged events
            waiter.StatusChanged += UpdateStatus;
            cook.StatusChanged += UpdateStatus;
            
            till.StatusChanged += UpdateStatus;
        }

        private void btnStartWaiter_Click(object sender, EventArgs e)
        {
            Thread waiterThread = new Thread(waiter.Serve);
            waiterThread.Start();
        }

        private void btnStartCook_Click(object sender, EventArgs e)
        {
            Thread cookThread = new Thread(cook.CookMeal);
            cookThread.Start();
        }

        private void btnStartCustomer_Click(object sender, EventArgs e)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer("Customer 1", restaurant),
                new Customer("Customer 2", restaurant)
            };
            foreach (var customer in customers)
            {
                customer.StatusChanged += UpdateStatus;
                customer.JoinRestaurantQueue();
            }
            
        }

        private void btnStartTill_Click(object sender, EventArgs e)
        {
            Thread tillThread = new Thread(till.HandlePayment);
            tillThread.Start();
        }

        private async void UpdateStatus(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateStatus(status)));
            }
            else
            {
                listBox1.Text = status;
                
            }
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void musteriSayisi_TextChanged(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
