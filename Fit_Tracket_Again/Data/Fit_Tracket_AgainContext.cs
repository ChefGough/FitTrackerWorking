using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fit_Tracket_Again.Models
{
    public class Fit_Tracket_AgainContext : DbContext
    {
        public Fit_Tracket_AgainContext (DbContextOptions<Fit_Tracket_AgainContext> options)
            : base(options)
        {
        }

        public DbSet<Fit_Tracket_Again.Models.WorkoutData> WorkoutData { get; set; }
    }
}
