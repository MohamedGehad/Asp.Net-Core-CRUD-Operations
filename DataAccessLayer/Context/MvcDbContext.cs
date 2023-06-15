using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
	public class MvcDbContext : IdentityDbContext<AppUsers>
	{


        public MvcDbContext(DbContextOptions<MvcDbContext> options): base(options)
        { 
        
        
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //  =>
        //	optionsBuilder.UseSqlServer("server =DESKTOP-S362RPV\\SQLEXPRESS  ; database = MvcProject ; trusted_connection = true");



        public DbSet<department> departments{ get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<IdentityUser> Users{ get; set; }
        //public DbSet<IdentityRole> Roles { get; set; }
    }

}
