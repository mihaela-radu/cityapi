using CityApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CityApi.Data
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions<CityDbContext> options) : base(options)
        { 
        }

        public DbSet<CityDto> Cities { get; set; }
    }
}
