﻿using System;
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
                if (_code == null)
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
                if (_name == null)
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
                if (_amount < 0)
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
                if (_price < 0.0)
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
                if (_category < 0)
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
            //ni idea de si estos están bien
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
    }
}
