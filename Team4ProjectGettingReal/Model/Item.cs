using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Team4ProjectGettingReal.Model
{
    internal class Item : ID
    {
        private string name;
        private string description;
        private double price;

        public string Name { get { return name; } }

        public Item(string name, string description, double price)
        {
            this.name = name;
            this.description = description;
            this.price = price;
        }
        public override string ToString()
        {
            return $"{name},{description},{price}";
        }
        public static ID FromString(string line)
        {
            string[] entries = line.Split(",");
            return new Item(entries[0], entries[1], Convert.ToInt32(entries[2]) );
        }
    }
}
