using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;

namespace MODEL
{
    public class gsms_Item
    {
        private string _name;
        private int _number;
        private string _brand;
        private int _code;
        private Image _photo;
        private string _specification;
        private string _classification;
        private string _origin;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
        }

        public int Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }

        public string Brand
        {
            get
            {
                return _brand;
            }

            set
            {
                _brand = value;
            }
        }

        public Image Photo
        {
            get
            {
                return _photo;
            }

            set
            {
                _photo = value;
            }
        }

        public string Specification
        {
            get
            {
                return _specification;
            }

            set
            {
                _specification = value;
            }
        }

        public string Classification
        {
            get
            {
                return _classification;
            }

            set
            {
                _classification = value;
            }
        }

        public string Origin
        {
            get
            {
                return _origin;
            }

            set
            {
                _origin = value;
            }
        }
    }
}
