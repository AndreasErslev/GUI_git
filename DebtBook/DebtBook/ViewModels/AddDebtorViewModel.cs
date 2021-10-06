using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtBook.ViewModels
{
    public class AddDebtorViewModel : BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private double _debt;
        public double Debt
        {
            get { return _debt; }
            set { SetProperty(ref _debt, value); }
        }
        public AddDebtorViewModel()
        {
           
        }

    }
}
