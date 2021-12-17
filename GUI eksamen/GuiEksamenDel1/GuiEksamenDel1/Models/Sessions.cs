using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Mvvm;

namespace GuiEksamenDel1.Models
{
    class Session: BindableBase
    {
        public string Dato { get; set; }
        public int BPM { get; set; }
        public int SessionTime { get; set; }
    }
}
