using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptBook.ViewModels
{
    public class AddDepterViewModel : BindableBase
    {
        public AddDepterViewModel(Depter newDepter)
        {
            CurrentDepter = newDepter;
        }

        private Depter _currentDepter;
        public Depter CurrentDepter
        {
            get { return _currentDepter; }
            set { SetProperty(ref _currentDepter, value); }
        }
    }
}
