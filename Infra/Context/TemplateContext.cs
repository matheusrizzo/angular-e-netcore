using Domain.Entities;
using Infra.Extensions;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class TemplateContext : DbContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.SeedData();
            modelBuilder.ApplyModelConfiguration();

            base.OnModelCreating(modelBuilder);
        }
    }
}