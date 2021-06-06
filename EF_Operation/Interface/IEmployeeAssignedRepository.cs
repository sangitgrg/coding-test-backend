using CodingTest.API_Result;
using CodingTest.Models;
using System.Collections.Generic;

namespace CodingTest.EF_Operation
{
    public interface IEmployeeAssignedRepository : IGenericRepository<EmployeeAssignedReview>
    {
        public object AssignEmployeeForReview(EmployeeAssigned_dto employeeAssignedReview);
        public List<EmployeeAssignedReview> GetAllEmployeeForReview();
        public object RemoveEmployeeForReview(EmployeeAssigned_dto employeeAssignedReview);
        public object UpdateEmployeeForReview(EmployeeAssigned_dto employeeAssignedReview);
    }
}
