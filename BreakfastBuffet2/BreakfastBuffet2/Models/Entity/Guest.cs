using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten_GruppeTo.Models.Entity
{
    public class Guest 
    {
        [Key]
        public int GuestId { get; set; }
        public string Room_Number { get; set; }
        public bool Adults { get; set; }
        public bool Children { get; set; }
        public bool Book { get; set; }
        public bool Check_In { get; set; }

    }
}
