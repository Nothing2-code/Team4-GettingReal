using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team4ProjectGettingReal.Model
{
    internal class Batch : ID
    {
        private Item item;
        private int batchNO;
        private DateTime date;
        private int total;
        private double purchasePrice;

        public Batch(Item item, int batchNO, DateTime date, int total)
        {
            this.item = item;
            this.batchNO = batchNO;
            this.date = date;
            this.total = total;
        }
        public override string ToString()
        {
            return $"{item.Name},{batchNO},{date},{total},{purchasePrice}";
        }
        //public Batch FromString(string line)
        //{
        //    string[] entries = line.Split(",");
        //    return new Batch(entries[0], batchNO, date, total);
        //}
    }
}
