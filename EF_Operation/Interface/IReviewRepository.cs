using CodingTest.API_Result;
using CodingTest.Models;
using System;
using System.Collections.Generic;

namespace CodingTest.EF_Operation
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        public Review CreateReview(Review_dto reviewDto);
        public bool CheckEmployeeAssignedForReview(Guid reviewerId, Guid tobeReviewedId);
        public IEnumerable<Review> GetAllReviewInformation();
        public IEnumerable<Review> GetOnlyAssignedReview(Guid userId);
    }
}
