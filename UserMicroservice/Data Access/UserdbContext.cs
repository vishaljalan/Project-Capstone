//using Microsoft.EntityFrameworkCore;
//using System;
//using UserMicroservice.Models;

//namespace UserMicroservice.Data_Access
//{
//    public class UserdbContext:DbContext
//    {
//        public UserdbContext(DbContextOptions<UserdbContext> options) : base(options)
//        {
//        }

//        public DbSet<Users> Users { get; set; }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Users>().ToTable("users");
                
            
//        }
//    }
//}
