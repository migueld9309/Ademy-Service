using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<UserType> UserTypes => Set<UserType>();
        public DbSet<Shift> Shifts => Set<Shift>();
        public DbSet<Grade> Grades => Set<Grade>();
    }
}
