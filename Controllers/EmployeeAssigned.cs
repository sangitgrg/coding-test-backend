using CodingTest.EF_Operation;
using CodingTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EmployeeAssigned : BaseController<EmployeeAssignedReview>
    {
        public EmployeeAssigned(IGenericRepository<EmployeeAssignedReview> repository) : base(repository)
        {
        }

    }
}
