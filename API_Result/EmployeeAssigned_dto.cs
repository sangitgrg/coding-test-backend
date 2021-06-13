using System;

namespace CodingTest.API_Result
{
    public class EmployeeAssigned_dto
    {
        public Guid Id { get; set; }
        public Guid ReviewerId { get; set; }
        public string ReviewerName { get; set; }

        public Guid GotReviewedId { get; set; }
        public string GotReviewedName { get; set; }

        public Guid AssignedById { get; set; }
        public string AssignedByName { get; set; }

        public DateTime AssignedDate { get; set; }
    }
}
