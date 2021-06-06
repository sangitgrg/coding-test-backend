using System;

namespace CodingTest.API_Result
{
    public class EmployeeAssigned_dto
    {
        public Guid Id { get; set; }
        public Guid ReviewerId { get; set; }
        public User_dto Reviewer { get; set; }

        public Guid ToBeReviewedId { get; set; }
        public User_dto ToBeReviewed { get; set; }

        public Guid AssignedById { get; set; }
        public User_dto AssignedBy { get; set; }
    }
}
