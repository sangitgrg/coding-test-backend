using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.API_Result
{
    public class UserAssigned_dto
    {
        public Guid UserId { get; set; }
        public string UserFullName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public Guid? AddedById { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public IEnumerable<Assigned_dto> assigned_Dtos { get; set; }
    }

    public class Assigned_dto
    {
        public Guid UserId { get; set; }
        public string UserFullName { get; set; }
    }

}
