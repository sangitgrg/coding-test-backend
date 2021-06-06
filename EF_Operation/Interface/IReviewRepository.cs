using CodingTest.Models;
using System;
using System.Collections.Generic;

namespace CodingTest.EF_Operation
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        public IEnumerable<Review> GetAllReviewInformation();
        public IEnumerable<Review> GetOnlyAssignedReview(Guid userId);
    }
}
