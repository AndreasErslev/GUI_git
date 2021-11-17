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
        public string RoomNbr { get; set; }
        public bool AdultCount { get; set; }
        public bool ChildCount { get; set; }
    }
}
