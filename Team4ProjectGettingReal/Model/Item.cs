using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Team4ProjectGettingReal.Model
{
    internal class Item : ID, INotifyPropertyChanged
    {
        private string name;
        private string description;
        private double price;
        private double amount;

        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public double Price { get { return price; } }
        public double Amount
        {
            get => amount;
            private set
            {
                if (amount != value)
                {
                    amount = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Item(string name, string description, double price, double amount)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.amount = amount;
        }
        public override string ToString()
        {
            return $"{name},{description},{price},{amount}";
        }
        public static ID FromString(string line)
        {
            string[] entries = line.Split(",");
            return new Item(entries[0], entries[1], Convert.ToInt32(entries[2]), Convert.ToInt32(entries[3]));
        }
        public void ReduceStock(double sold)
        {
            if (sold <= Amount)
                Amount -= sold;
            else
                throw new InvalidOperationException("Not enough in stock.");
        }



    }
}
