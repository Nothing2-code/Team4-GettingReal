using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team4ProjectGettingReal.Repository
{
    internal interface DataHandler
    {
        string FilePath { get;}
        public void SaveFile (List<object> files,string FilePath);
        public void LoadFile(string FilePath);
    }
}
