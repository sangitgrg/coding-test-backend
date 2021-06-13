using System;
using System.Collections.Generic;

namespace CodingTest.API_Result
{
    public class User_dto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public Guid AddedById { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<UserAssigned_dto> EmployeeToBeReviewed { get; set; }
    }
}
