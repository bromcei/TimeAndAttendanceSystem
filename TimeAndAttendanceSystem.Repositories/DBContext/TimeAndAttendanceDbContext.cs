using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Repositories.DBContext
{
    public class TimeAndAttendanceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection"));
            options.UseSqlServer($@"Data Source=localhost;Initial Catalog=TimeAndAttendanceDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(u => u.Details).WithOne(ud => ud.User).HasForeignKey<UserDetails>(ud => ud.UserId);
            modelBuilder.Entity<User>().HasOne(u => u.Photo).WithOne(up => up.User).HasForeignKey<UserPhoto>(up => up.UserId);
            modelBuilder.Entity<User>().HasOne(u => u.Address).WithOne(ua => ua.User).HasForeignKey<UserAddress>(ua => ua.UserId);
        }

    }
}
