﻿using CodingTest.API_Result;
using CodingTest.Models;
using System;
using System.Collections.Generic;

namespace CodingTest.EF_Operation
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        public IEnumerable<UserAssigned_dto> GetAllUsers();
        public IEnumerable<EmployeeAssignedReview> GetEmployeeAssignedToMe(Guid userId);
        public object AssignEmployeeForReview(EmployeeAssigned_dto employeeAssignedReview);
        public List<EmployeeAssignedReview> GetAllEmployeeForReview();
        public object RemoveEmployeeForReview(EmployeeAssigned_dto employeeAssignedReview);
        public object UpdateEmployeeForReview(EmployeeAssigned_dto employeeAssignedReview);
        public Users LoginUser(Login_dto login_Dto);
        public Users UpdateUser(User_dto user);
    }
}
