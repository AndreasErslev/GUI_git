using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtBook
{
    public class Debtor
    {
        //Fields
        private string _name;
        private double _debt;
        public ObservableCollection<double> ListOfDebts = new ObservableCollection<double>();

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

        public double Debt
        {
            get
            {
                return _debt;
            }
            set
            {
                _debt = value;
            }
        }
        public Debtor() { }
        public Debtor(string name, double debt)
        {
            _name = name;
            AddDebt(debt);
        }
        public void AddDebt(double valueToAdd)
        {
            _debt += valueToAdd;
            ListOfDebts.Add(valueToAdd);
        }
    }
}
