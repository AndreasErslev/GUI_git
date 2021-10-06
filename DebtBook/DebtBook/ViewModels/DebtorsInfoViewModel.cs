using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtBook.ViewModels
{
    public class DebtorInfoViewModel : BindableBase
    {

        // property AllDebts som returnerer ListOfDebts af typen ObservableCollection<double>
        public ObservableCollection<double> AllDebts
        {
            get { return CurrentDebtor.ListOfDebts; }
            set { SetProperty(ref CurrentDebtor.ListOfDebts, value); }
        }


        private Debtor _currentDebtor;
        public Debtor CurrentDebtor
        {
            get { return _currentDebtor; }
            set { SetProperty(ref _currentDebtor, value); }
        }


        // forbindelse til label 'Value' i DebtorsInfoWindow.xaml
        private double _newDebt = 0;
        public double NewDebt
        {
            get { return _newDebt; }
            set { SetProperty(ref _newDebt, value); }
        }


        // forbindelse til button 'Add Value' for at add i DebtorsInfoWindow.xaml
        private DelegateCommand _addDebt;
        public DelegateCommand AddDebt =>
            _addDebt ?? (_addDebt = new DelegateCommand(ExecuteAddDebt));
        void ExecuteAddDebt()
        {
            CurrentDebtor.AddDebt(NewDebt);
        }


        public DebtorInfoViewModel(Debtor currentDebtor)
        {
            CurrentDebtor = currentDebtor;
        }

    }
}
