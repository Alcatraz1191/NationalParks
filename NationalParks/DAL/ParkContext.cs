
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using NationalParks.Models;
namespace NationalParks.DAL
{
    public class ParkContext : DbContext
    {
        public ParkContext(): base("name=ParkContext")
        {
        }

        public virtual DbSet<Park> Parks { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
