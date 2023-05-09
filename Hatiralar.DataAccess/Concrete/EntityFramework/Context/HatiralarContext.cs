using Hatiralar.DataAccess.Concrete.EntityFramework.Maps;
using Hatiralar.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.DataAccess.Concrete.EntityFramework.Context
{
    public class HatiralarContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new CityMap());
            builder.ApplyConfiguration(new NotebookMap());
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = SEGO\SQLEXPRESS;Database=HatiralarDb;Integrated Security = true;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Notebook> Notebooks { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
