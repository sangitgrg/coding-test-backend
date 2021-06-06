using CodingTest.Models;

namespace CodingTest.EF_Operation
{
    public class EmployeeAssignedRepository : GenericRepository<EmployeeAssignedReview>
    {
        public EmployeeAssignedRepository(CodingTestDbContext context) : base(context)
        {
        }


    }
}
