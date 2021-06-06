using CodingTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTest.EF_Operation
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(CodingTestDbContext _context) : base(_context)
        {
        }

        public IEnumerable<Review> GetAllReviewInformation()
        {
            return _context.Reviews.Include(x => x.Reviewer).Include(x => x.GotReviewed).AsEnumerable();
        }

        public IEnumerable<Review> GetOnlyAssignedReview(Guid userId)
        {
            return _context.Reviews.Where(r => r.ReviewerId == userId).Include(x => x.Reviewer).Include(x => x.GotReviewed).AsEnumerable();
        }
    }
}
