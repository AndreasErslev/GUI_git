using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Morgenmadsbuffeten_GruppeTo.Models.Entity;

namespace BreakfastBuffet2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Morgenmadsbuffeten_GruppeTo.Models.Entity.Guest> Guest { get; set; }

    }
}
