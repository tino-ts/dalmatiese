using Dalmatiese.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dalmatiese.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
    }