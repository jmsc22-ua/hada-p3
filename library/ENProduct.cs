using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        public string Code
        {
            get { return _code; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("code");
                }
                _code = value;
            }
        }
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
        public int Amount
        {
            get { return _amount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("amount");
                }
                _amount = value;
            }
        }
        public float Price
        {
            get { return _price; }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentNullException("price");
                }
                _price = value;
            }
        }
        public int Category
        {
            get { return _category; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("category");
                }
                _category = value;
            }
        }
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set
            {
                if (value < DateTime.MinValue)
                {
                    throw new ArgumentOutOfRangeException("Wrong date");
                }
                _creationDate = value;
            }
        }
        public ENProduct()
        {
            Code = " ";
            Name = " ";
            Amount = 0;
            Price = 0;
            Category = 0;
            CreationDate = DateTime.MinValue;
        }
        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            Code = code;
            Name = name;
            Amount = amount;
            Price = price;
            Category = category;
            CreationDate = creationDate;
        }

        public bool Create()
        {
            CADProduct cad = new CADProduct();
            return cad.Create(this);
        }

        public bool Update()
        {
            CADProduct cad = new CADProduct();
            return cad.Update(this);
        }

        public bool Delete()
        {
            CADProduct cad = new CADProduct();
            return cad.Delete(this);
        }

        public bool Read()
        {
            CADProduct cad = new CADProduct();
            return cad.Read(this);
        }

        public bool ReadFirst()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadFirst(this);
        }

        public bool ReadNext()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadNext(this);
        }

        public bool ReadPrev()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadPrev(this);
        }
    }
}
