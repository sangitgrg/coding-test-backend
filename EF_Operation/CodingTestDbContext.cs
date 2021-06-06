using CodingTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingTest.EF_Operation
{
    public class CodingTestDbContext : DbContext
    {
        public CodingTestDbContext(DbContextOptions<CodingTestDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAssignedReview>()
                .HasKey(EA => new { EA.ReviewerId, EA.ToBeReviewedId, EA.AssignedById });
            modelBuilder.Entity<EmployeeAssignedReview>()
                .HasOne(ea => ea.Reviewer)
                .WithMany(e => e.ReviewerEmployee)
                .HasForeignKey(ea => ea.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmployeeAssignedReview>()
                .HasOne(ea => ea.ToBeReviewed)
                .WithMany(e => e.EmployeeToBeReviewed)
                .HasForeignKey(ea => ea.ToBeReviewedId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Users>()
                .HasMany(re => re.ListOfReviewer)
                .WithOne(r => r.Reviewer)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Users>()
                .HasMany(re => re.ListOFReviewed)
                .WithOne(r => r.GotReviewed);
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<EmployeeAssignedReview> EmployeeAssignedReviews { get; set; }
    }
}
