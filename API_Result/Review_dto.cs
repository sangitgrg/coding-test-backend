using System;

namespace CodingTest.API_Result
{
    public class Review_dto
    {
        public Guid Id { get; set; }
        public int Point { get; set; }
        public string FeedBack { get; set; }
        public Guid ReviewerId { get; set; }
        public string ReviewerName { get; set; }
        public Guid GotReviewedId { get; set; }
        public string GotReviewedName { get; set; }
        public DateTime ReviewedDate { get; set; }
    }
}
