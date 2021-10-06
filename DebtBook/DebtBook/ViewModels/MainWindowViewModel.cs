using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DebtBook.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace DebtBook.ViewModels
{

    public class MainWindowViewModel : BindableBase
    {
        //Binding til Add-button commando
        private ICommand _addDebtor;
        public ICommand AddDebtor =>
            _addDebtor ?? (_addDebtor = new DelegateCommand(ExecuteAddDebtor));

        void ExecuteAddDebtor()
        {
            var vmDebtor = new AddDebtorViewModel();
            var dialog = new AddDebtorDialog(vmDebtor);

            //Hvis der trykkes save tilføjer vi ny debtor til listen
            if(dialog.ShowDialog() == true)
            {
                var newDebtor = new Debtor(vmDebtor.Name, vmDebtor.Debt);
                Debtors.Insert(0, newDebtor);
                CurrentDebtor = newDebtor;
            }
            //Else: Hvis der trykkes cancel
        }

        private DelegateCommand _openInfo;
        public DelegateCommand OpenInfo =>
            _openInfo ?? (_openInfo = new DelegateCommand(ExecuteOpenInfo));

        void ExecuteOpenInfo()
        {
            var vmInfo = new DebtorInfoViewModel(CurrentDebtor);
            var dialog = new DebtorsInfoWindow(vmInfo);

            // Inde i DebtorsInfoViewModel.cs:
            // debt er tilføjet via DebtorInfoViewModel til CurrentDebtor.AddDebt,
            // som opdaterer debt sum og add af debt til ListOfDebt
            dialog.ShowDialog();

            // Opdater datagrid, når der trykkes close
            Debtors = new ObservableCollection<Debtor>(Debtors.ToList());
        }


        public MainWindowViewModel()
        {
            //Tilføjer debtors
            _listOfDebtors.Add(new Debtor("Torben", -100.50));
            _listOfDebtors.Add(new Debtor("Kurt", 563.28));
            _listOfDebtors.Add(new Debtor("Joanna", -5204.00));
        }


        private ObservableCollection<Debtor> _listOfDebtors = new ObservableCollection<Debtor>();
        public ObservableCollection<Debtor> Debtors
        {
            get { return _listOfDebtors; }
            set { SetProperty(ref _listOfDebtors, value); }
            //Laver selv notify
        }

        private Debtor _currentDebtor;
        public Debtor CurrentDebtor
        {
            get { return _currentDebtor; }
            set { SetProperty(ref _currentDebtor, value); }
        }

    }
}
