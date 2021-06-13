using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingTest.Models
{
    public class Users : IBaseData
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public int Age { get; set; }
        [StringLength(10)]
        public string Sex { get; set; } // for future purpose enum type will be better
        public Guid? AddedById { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<EmployeeAssignedReview> ReviewerEmployee { get; set; }
        public ICollection<EmployeeAssignedReview> EmployeeToBeReviewed { get; set; }
    }
}

