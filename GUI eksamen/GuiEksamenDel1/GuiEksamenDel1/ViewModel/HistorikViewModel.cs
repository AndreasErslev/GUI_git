using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GuiEksamenDel1.Models;
using Prism.Commands;

namespace GuiEksamenDel1.ViewModel
{
    class HistorikViewModel
    {
        public List<Session> sessionList { get; set; }

        private Window _currentWindow { get; }

        public int Totalamount { get; set; }
        
        public HistorikViewModel(Window window)
        {
            _currentWindow = window;
            sessionList = new List<Session>();
            loadSessions();
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


        private void loadSessions()
        {
            Totalamount = 0;
            string filepath = @"C:\Users\jacob\Desktop\GUI eksamen\Sessions.txt";
            List<string> lines = File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                Session newSession = new Session();
                newSession.SessionTime = Convert.ToInt32(entries[0]);
                newSession.BPM = Convert.ToInt32(entries[1]);
                newSession.Dato = entries[2];

                Totalamount += Convert.ToInt32(entries[0]); 
                sessionList.Add(newSession);
            }
        }
    }
}
