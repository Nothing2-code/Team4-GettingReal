using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team4ProjectGettingReal.Model;

namespace Team4ProjectGettingReal.Repository
{
    internal class FileItemRepository : IRepository
    {
        private static readonly string filePath = "item.txt";

        private static List<ID> items = new List<ID>();

        public static void LoadItems ()
        {
            if (File.Exists (filePath))
            {
                items = File.ReadAllLines (filePath).Select(Item.FromString).ToList ();
            }
        }

        public void Add(ID item)
        {
            throw new NotImplementedException();
        }

        public void Delete(ID item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ID> GetAll()
        {
            throw new NotImplementedException();
        }

        public ID GetByID(ID id)
        {
            throw new NotImplementedException();
        }

        public void Update(ID item)
        {
            throw new NotImplementedException();
        }
    }
}
