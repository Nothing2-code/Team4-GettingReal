using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team4ProjectGettingReal.Model
{
    internal class Storage : ID
    {
        private int position;
        public Storage (int position)
        {
            this.position = position;
        }
    }
}
