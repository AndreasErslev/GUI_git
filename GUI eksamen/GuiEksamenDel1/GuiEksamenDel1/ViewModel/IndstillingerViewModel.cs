using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace GuiEksamenDel1.ViewModel
{
    class IndstillingerViewModel: BindableBase
    {
        public int _BreathTime { get; set; }

        public int _BreathFrequency { get; set; }

        private Window _currentWindow { get; }

        public IndstillingerViewModel(Window window)
        {
            _currentWindow = window;
        }


        private ICommand cancelCommand;

        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ??= new DelegateCommand(CancelCommandHandler);
            }
        }

        private void CancelCommandHandler()
        {
            _currentWindow.Close();
        }

        private ICommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ??= new DelegateCommand(SaveCommandHandler);
            }
        }

        private void SaveCommandHandler()
        {
            try
            {
                int oldBreath = Properties.Settings.Default.Breath;
                int oldfreq = Properties.Settings.Default.Frequency;
                if (_BreathFrequency >= 5 && _BreathFrequency <= 7)
                {
                    Properties.Settings.Default.Frequency = _BreathFrequency;
                }
                else
                {
                    MessageBox.Show("BreathTime skal være mellem 5-7");
                    Properties.Settings.Default.Frequency = oldfreq;
                }

                if (_BreathTime >= 1 && _BreathTime <= 20)
                {
                    Properties.Settings.Default.Breath = _BreathTime;
                    
                }
                else
                {
                    MessageBox.Show("Længden af sessionen skal være mellem 1-20 minutter");
                    Properties.Settings.Default.Breath = oldBreath;
                }

                
            }
            catch (Exception)
            {
                MessageBox.Show("indtast kun talværdier");
            }
            

            Properties.Settings.Default.Save();
            _currentWindow.Close();
        }

    }
}
