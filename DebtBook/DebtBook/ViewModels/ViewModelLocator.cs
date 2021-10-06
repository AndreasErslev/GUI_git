using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtBook.ViewModels
{
    public class ViewModelLocator
    {
        //Bruges til binde View med ViewModel
        public MainWindowViewModel ViewModel
        {
            get { return new MainWindowViewModel();}
        }
    }
}
