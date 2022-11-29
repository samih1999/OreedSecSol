using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CustomerModel> customers { get; set; }
        public DbSet<OrderModel> orders { get; set; }
        public DbSet<SpeccialOrderModel> normalorders { get; set; }
        public DbSet<NormalOrderModel> specialorders { get; set; }
    }
}
