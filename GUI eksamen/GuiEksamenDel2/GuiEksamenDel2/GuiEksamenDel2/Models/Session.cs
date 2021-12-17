using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiEksamenDel2.Models
{
    public class Session
    {
        
        public Guid SessionId { get; set; }
        public int BPM { get; set; }
        public int SessionLength { get; set; }
        
        public DateTime Dato { get; set; }
    }
}
