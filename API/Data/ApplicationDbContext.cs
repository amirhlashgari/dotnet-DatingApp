using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDbContext : DbContext // our class is derived from dbcontext class of entity framework. creates a session with database and we don't connect to it directly
{
    public ApplicationDbContext(DbContextOptions options) : base(options) // to pass options to DBContext itself
    {

    }
    public DbSet<AppUser> Users { get; set; } // this field name tells table name

}
