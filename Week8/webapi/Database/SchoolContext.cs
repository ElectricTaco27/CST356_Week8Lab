using System.Collections.Generic;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)         
        {         
        }
        
        public DbSet<Person> Person { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}