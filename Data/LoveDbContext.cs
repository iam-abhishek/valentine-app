using Microsoft.EntityFrameworkCore;
using myvapp.Models;
using System.Collections.Generic;

namespace myvapp.Data
{
   
    public class LoveDbContext : DbContext
    {
        public LoveDbContext(DbContextOptions<LoveDbContext> options)
            : base(options) { }

        public DbSet<ValentineResponse> ValentineResponses { get; set; }
        public DbSet<LoveFeedback> LoveFeedbacks { get; set; }
    }

}
