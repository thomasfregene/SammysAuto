using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SammysAuto.Models;

namespace SammysAuto.Data
{
    public class ApplicationDbContext : IdentityDbContext<SammysAutoApplicationUser, SammysAutoApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<ServiceType> ServiceTypes { get; set; }

    }
}
