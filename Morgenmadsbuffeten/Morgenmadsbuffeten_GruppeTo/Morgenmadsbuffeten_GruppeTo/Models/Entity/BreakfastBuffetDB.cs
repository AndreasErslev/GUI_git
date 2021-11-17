using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten_GruppeTo.Models.Entity
{
    public class BreakfastBuffetDB
    {
        [Key]
        public int ReceptiontId { get; set; }
        public List<Guest> GuestBreakfastBookings { get; set; }
        public List<Guest> GuestBreakfastCheckedIn { get; set; }

    }
}
