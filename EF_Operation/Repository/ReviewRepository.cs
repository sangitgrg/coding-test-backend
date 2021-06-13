using CodingTest.API_Result;
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

        public Review CreateReview(Review_dto reviewDto)
        {
            Review review = new Review
            {
                Point = reviewDto.Point,
                FeedBack = reviewDto.FeedBack,
                ReviewedDate = DateTime.Today,
                ReviewerId = reviewDto.ReviewerId,
                GotReviewedId = reviewDto.GotReviewedId
            };
            _context.Add(review);
            _context.SaveChanges();
            return review;
        }

        public bool CheckEmployeeAssignedForReview(Guid reviewerId, Guid tobeReviewedId)
        {
            var x = _context.EmployeeAssignedReviews.Where(x => x.ToBeReviewedId == tobeReviewedId && x.ReviewerId == reviewerId).Any();
            return x;
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
