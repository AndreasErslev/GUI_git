using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using DebtBook.Views;
using Microsoft.Win32;
using Newtonsoft.Json;
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
            // debt er tilføjet via CurrentDebtor.AddDebt,
            // som opdaterer debt sum og add af debt til ListOfDebt
            dialog.ShowDialog();

            // Opdater datagrid, når der trykkes close/lukker dialog
            Debtors = new ObservableCollection<Debtor>(Debtors.ToList());
        }

        private ICommand saveFile;
        public ICommand SaveFile
        {
            get
            {
                return saveFile ?? (saveFile = new DelegateCommand(() =>
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        var json = JsonConvert.SerializeObject(Debtors, Newtonsoft.Json.Formatting.Indented);

                        using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                        {
                            sw.WriteLine(json);
                        }
                    }

                }
                ));
            }
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
