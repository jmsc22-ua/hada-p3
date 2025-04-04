using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCategory
    {
        private string _name;
        private int _id;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("name");
                }
                _name = value;
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public ENCategory()
        {
            Name = " ";
            Id = 0;
        }
        public ENCategory(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public bool Read()
        {
            CADCategory cad = new CADCategory();
            return cad.Read(this);
        }

        public List<ENCategory> ReadAll()
        {
            CADCategory cad = new CADCategory();
            return cad.ReadAll();
        }

    }
}
