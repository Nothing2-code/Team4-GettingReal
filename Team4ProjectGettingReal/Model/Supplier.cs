using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team4ProjectGettingReal.Model
{
    internal class Supplier : ID
    {
        private string name;
        private string adresse;
        private string phoneNumber;
        private TimeSpan deliveryTime;

        public Supplier (string name, string adresse, string phoneNumber, TimeSpan deliveryTime)
        {
            this.name = name;
            this.adresse = adresse;
            this.phoneNumber = phoneNumber;
            this.deliveryTime = deliveryTime;
        }

        public void Contact()
        { }
    }
}
