using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GuiEksamenDel1.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace GuiEksamenDel1.ViewModel
{
    class MainWindowViewModel : BindableBase
    {
        private ICommand indstillingerCommand;

        public ICommand IndstillingerCommand
        {
            get
            {
                return indstillingerCommand ??= new DelegateCommand(IndstillingerCommandHandler);
            }
        }
        public void IndstillingerCommandHandler()
        {
            IndstillingerView indstillingerPage = new IndstillingerView();
            indstillingerPage.DataContext = new IndstillingerViewModel(indstillingerPage);
            indstillingerPage.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            indstillingerPage.ShowDialog();
        }

        private ICommand startCommand;

        public ICommand StartCommand
        {
            get
            {
                return startCommand ??= new DelegateCommand(StartCommandHandler);
            }
        }

        public void StartCommandHandler()
        {
            StartBreathing startBreathing = new StartBreathing();
            startBreathing.DataContext = new StartBreathingViewModel(startBreathing);
            startBreathing.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            startBreathing.ShowDialog();
        }

        private ICommand historikCommand;
        public ICommand HistorikCommand
        {
            get
            {
                return historikCommand ??= new DelegateCommand(HistorikCommandHandler);
            }
        }

        public void HistorikCommandHandler()
        {
            HistorikView historikView = new HistorikView();
            historikView.DataContext = new HistorikViewModel(historikView);
            historikView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            historikView.ShowDialog();
        }
    }
}