using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    // On event model creating
        //    base.OnModelCreating(builder);

        //    ////Seeding a  'Administrator' role to AspNetRoles table
        //    //builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });

        //    ////a hasher to hash the password before seeding the user to the db
        //    //var hasher = new PasswordHasher<IdentityUser>();


        //    ////Seeding the User to AspNetUsers table
        //    //builder.Entity<IdentityUser>().HasData(
        //    //    new IdentityUser
        //    //    {
        //    //        Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
        //    //    UserName = "myuser",
        //    //        NormalizedUserName = "admin",
        //    //        PasswordHash = hasher.HashPassword(null, "123456")
        //    //    }
        //    //);


        //    ////Seeding the relation between our user and role to AspNetUserRoles table
        //    //builder.Entity<IdentityUserRole<string>>().HasData(
        //    //    new IdentityUserRole<string>
        //    //    {
        //    //        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
        //    //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
        //    //    }
        //    //);

        //}
    }
}
