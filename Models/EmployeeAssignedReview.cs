using System;

namespace CodingTest.Models
{
    public class EmployeeAssignedReview : IBaseData
    {
        public Guid ReviewerId { get; set; }
        public Users Reviewer { get; set; }

        public Guid ToBeReviewedId { get; set; }
        public Users ToBeReviewed { get; set; }

        public Guid AssignedById { get; set; }
        public Users AssignedBy { get; set; }
        public DateTime AssignedDate { get; set; }
        public Guid Id { get; set; }
    }
}
