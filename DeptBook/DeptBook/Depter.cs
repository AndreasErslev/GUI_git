using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptBook
{
    public class Depter
    {
        //Fields
        private string _name;
        private double _dept;

        //Properties
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

        public double Dept
        {
            get
            {
                return _dept;
            }
            set
            {
                _dept = value;
            }
        }

        public Depter()
        {

        }

        public Depter(string name, double dept)
        {
            _name = name;
            _dept = dept;
        }

       

    }
}
