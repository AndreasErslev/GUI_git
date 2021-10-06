using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DeptBook.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace DeptBook.ViewModels
{

    public class MainWindowViewModel : BindableBase
    {
        //Binding til Add-button commando
        private ICommand _addDepter;
        public ICommand AddDepter =>
            _addDepter ?? (_addDepter = new DelegateCommand(ExecuteAddDepter));

        void ExecuteAddDepter()
        {
            var newDepter = new Depter();
            var vmDepter = new AddDepterViewModel(newDepter);
            var dialog = new AddDepterDialog(vmDepter);

            //Hvis der trykkes save tilføjer vi ny depter til listen
            if(dialog.ShowDialog() == true)
            {
                Depters.Insert(0, newDepter);
                CurrentDepter = newDepter;
            }
            //Else: Hvis der trykkes cancel
        }

        private DelegateCommand _openInfo;
        public DelegateCommand OpenInfo =>
            _openInfo ?? (_openInfo = new DelegateCommand(ExecuteOpenInfo));

        void ExecuteOpenInfo()
        {
            var vmInfo = new DepterInfoViewModel(CurrentDepter);
            var dialog = new DeptersInfoWindow(vmInfo);

            //Hvis der trykkes save tilføjer vi ny depter til listen
            if (dialog.ShowDialog() == true)
            {
                //Updatere currentDept
                CurrentDepter.UpdateDept(CurrentDepter.Dept); 
            }
            //Else: Hvis der trykkes close
         }


        public MainWindowViewModel()
        {
            //Tilføjer depters
            _listOfDepters.Add(new Depter("Torben", -100.50));
            _listOfDepters.Add(new Depter("Kurt", 563.28));
            _listOfDepters.Add(new Depter("Joanna", -5204.00));
        }


        private ObservableCollection<Depter> _listOfDepters = new ObservableCollection<Depter>();
        public ObservableCollection<Depter> Depters
        {
            get { return _listOfDepters; }
            set { SetProperty(ref _listOfDepters, value); }
            //Laver selv notify
        }

        private Depter _currentDepter;
        public Depter CurrentDepter
        {
            get { return _currentDepter; }
            set { SetProperty(ref _currentDepter, value); }
        }

    }
}
