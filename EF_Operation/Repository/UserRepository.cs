using CodingTest.API_Result;
using CodingTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTest.EF_Operation
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        public UserRepository(CodingTestDbContext _context) : base(_context)
        {
        }

        public IEnumerable<EmployeeAssignedReview> GetReviewsAssignedToMe(Guid userId)
        {
            var res = _context.EmployeeAssignedReviews.Include(c => c.ToBeReviewed).Where(x => x.ReviewerId == userId);
            return res;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _context.Users.AsEnumerable();
        }

        public Users LoginUser(Login_dto login_Dto)
        {
            var res = _context.Users.Where(x => x.Email == login_Dto.Email).FirstOrDefault();
            if (res != null)
                return res.Password == login_Dto.Password ? res : null;
            return null;
        }

        public object AssignEmployeeForReview(EmployeeAssigned_dto employeeAssignedReview)
        {
            if (_context.EmployeeAssignedReviews.Where(x => x.ReviewerId == employeeAssignedReview.ReviewerId &&
                                                       x.ToBeReviewedId == employeeAssignedReview.ToBeReviewedId).Any())
                return "This record is already in database.";
            EmployeeAssignedReview newEmployeeAssigned = new EmployeeAssignedReview
            {
                Id = Guid.NewGuid(),
                AssignedById = employeeAssignedReview.AssignedById,
                ReviewerId = employeeAssignedReview.ReviewerId,
                ToBeReviewedId = employeeAssignedReview.ToBeReviewedId,
                AssignedDate = DateTime.Now,
            };

            _context.EmployeeAssignedReviews.Add(newEmployeeAssigned);
            _context.SaveChanges();
            return newEmployeeAssigned;
        }

        public List<EmployeeAssignedReview> GetAllEmployeeForReview()
        {
            var res = _context.EmployeeAssignedReviews.Include(x => x.Reviewer)
                               .Include(x => x.ToBeReviewed)
                               .Include(x => x.AssignedBy).AsEnumerable<EmployeeAssignedReview>();
            return res.ToList();
        }

        public object RemoveEmployeeForReview(EmployeeAssigned_dto employeeAssignedReview)
        {

            if (_context.EmployeeAssignedReviews.Where(x => x.ReviewerId == employeeAssignedReview.ReviewerId &&
                                                       x.ToBeReviewedId == employeeAssignedReview.ToBeReviewedId).Any())
            {
                var toRemove = _context.EmployeeAssignedReviews.Where(x => x.ReviewerId == employeeAssignedReview.ReviewerId && x.ToBeReviewedId == employeeAssignedReview.ToBeReviewedId)?.First();
                _context.EmployeeAssignedReviews.Remove(toRemove);
                _context.SaveChanges();
                return "Successfully Removed";
            }
            return "This record is not present in database";

        }

        public object UpdateEmployeeForReview(EmployeeAssigned_dto employeeAssignedReview)
        {
            if (_context.EmployeeAssignedReviews.Where(x => x.ReviewerId == employeeAssignedReview.ReviewerId &&
                                                       x.ToBeReviewedId == employeeAssignedReview.ToBeReviewedId).Any())
                return "This record is already in database.";
            EmployeeAssignedReview employeeAssigned = new EmployeeAssignedReview
            {
                AssignedById = employeeAssignedReview.AssignedById,
                ReviewerId = employeeAssignedReview.ReviewerId,
                ToBeReviewedId = employeeAssignedReview.ToBeReviewedId,
                AssignedDate = DateTime.Now
            };
            _context.EmployeeAssignedReviews.Attach(employeeAssigned);
            _context.Entry(employeeAssigned).State = EntityState.Modified;
            _context.SaveChanges();
            return employeeAssigned;
        }
    }
}
