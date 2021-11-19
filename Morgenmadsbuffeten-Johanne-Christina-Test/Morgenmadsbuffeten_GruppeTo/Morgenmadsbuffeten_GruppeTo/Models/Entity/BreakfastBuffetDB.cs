using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten_GruppeTo.Models.Entity
{
    public class BreakfastBuffetDB
    {
        [Key]
        public int BreakfastBuffetDBId { get; set; }
        //[NotMapped]
        //public List<Guest> GuestBreakfastBookings { get; set; }
        //[NotMapped]
        //public List<Guest> GuestBreakfastCheckedIn { get; set; }

    }
}
