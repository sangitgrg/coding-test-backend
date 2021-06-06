using System;

namespace CodingTest.Models
{
    public class Review : IBaseData
    {
        public Guid Id { get; set; }
        public int Point { get; set; }
        public string FeedBack { get; set; }
        public DateTime ReviewedDate { get; set; }
        public Guid ReviewerId { get; set; }
        public Users Reviewer { get; set; }
        public Guid GotReviewedId { get; set; }
        public Users GotReviewed { get; set; }
    }
}
