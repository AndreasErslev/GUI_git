using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Prism.Commands;
using Prism.Mvvm;

namespace GuiEksamenDel1.ViewModel
{
    class StartBreathingViewModel: BindableBase
    {

        public int BPM { get; set; }

        private string breath;
        private int changeBreath;

        public string Breath
        {
            get
            {
                return breath;
            }
            set
            {
                breath = value;
                RaisePropertyChanged("Breath");
            }
        }

        private int currentTime;

        public int CurrentTime
        {
            get
            {
                return currentTime;
            }
            set
            {
                currentTime = value;
                RaisePropertyChanged("CurrentTime");
            }
        }

        private Window _currentWindow { get; }
        private DispatcherTimer Timer = new DispatcherTimer();
        public StartBreathingViewModel(Window window)
        {
            _currentWindow = window;
            BPM = 60 / Properties.Settings.Default.Frequency;

            Timer.Tick += new EventHandler(Timer_Tick);
            CurrentTime = Properties.Settings.Default.Breath * 60;
            Timer.Interval = new TimeSpan(0,0,1);
            Timer.Start();
            changeBreath = CurrentTime-1;
        }

        
        private void Timer_Tick(object sender, EventArgs e)
        {
            
            CurrentTime -= 1;
            if (changeBreath == currentTime)
            {
                if (Breath != "Breath In")
                {
                    Breath = "Breath In";
                }
                else
                {
                    Breath = "Breath Out";
                }

                changeBreath -= BPM / 2;
            }

            if (CurrentTime == 0)
            {
                Timer.Stop();
                LogSession();
            }
            
        }

        private void LogSession()
        {
            string filepath = @"C:\Users\jacob\Desktop\GUI eksamen\Sessions.txt";
            List<string> lines = File.ReadAllLines(filepath).ToList();
            string SessionToAdd =
                $"{Properties.Settings.Default.Breath.ToString()},{Properties.Settings.Default.Frequency.ToString()},{DateTime.Today}";
            lines.Add(SessionToAdd);
            File.WriteAllLines(filepath,lines);
        }
    }
}
