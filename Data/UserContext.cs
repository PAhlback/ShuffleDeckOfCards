using Microsoft.EntityFrameworkCore;
using ShuffleDeckOfCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleDeckOfCards.Data
{
    internal class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\.;Initial Catalog=BlackjackDatabase;Integrated Security=True;Pooling=False");
        }
    }
}
