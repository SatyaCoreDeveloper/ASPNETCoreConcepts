using DemoCoreMVCConcepts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace DemoCoreMVC.Data.Data
{
    public class CoreMVCContext: DbContext 
    {
        public CoreMVCContext(DbContextOptions<CoreMVCContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Customer>()
                .HasOne<Address>();
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
