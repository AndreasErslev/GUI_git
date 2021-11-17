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
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
    }
}
