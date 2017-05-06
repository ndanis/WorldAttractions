using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldAttractions.DAL.Models.Showplace;
using WorldAttractions.DAL.Models.Users;

namespace WorldAttractions.DAL.EF
{
    public class BelarusAttractionsContext : DbContext
    {
        public BelarusAttractionsContext()
            : base("BelarusAttractionsContext")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Monument> Monuments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
