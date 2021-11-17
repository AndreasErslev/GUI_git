using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Morgenmadsbuffeten_GruppeTo.Models.Entity;

namespace Morgenmadsbuffeten_GruppeTo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<BreakfastBuffetDB> breakfastBuffets { get; set; }
        DbSet<Guest> guests { get; set; }

    }
}
