using Microsoft.EntityFrameworkCore;
using PhoneBookApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApi.DAL.Context
{
    public class PhoneBookApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=OMER\SQLEXPRESS;Database=PhoneBookDb;Trusted_Connection=true");
        }

        public DbSet<Person> Persons { get; set; }
    }
}
