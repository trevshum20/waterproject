using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WaterProject.Models
{
    public class AppIdentityDBContext : IdentityDbContext<IdentityUser>
    // we're creating  class called app id db context that inherits from id db context of type id user
    {
        public AppIdentityDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
