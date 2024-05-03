using MentorInClass.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorInClass.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<PricingFeature> PricingFeatures { get; set; }
    }
}
