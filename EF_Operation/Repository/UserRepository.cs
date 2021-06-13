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

        public IEnumerable<EmployeeAssignedReview> GetEmployeeAssignedToMe(Guid userId)
        {
            var res = _context.EmployeeAssignedReviews
                .Include(c => c.Reviewer)
                .Include(c => c.ToBeReviewed)
                .Include(c => c.AssignedBy)
                .Where(x => x.ReviewerId == userId);
            return res;
        }

        public IEnumerable<UserAssigned_dto> GetAllUsers()
        {
            var result = (from user in _context.Users.AsEnumerable()
                          select new UserAssigned_dto
                          {
                              UserId = user.Id,
                              UserFullName = user.FirstName + " " + user.LastName,
                              Age = user.Age,
                              Sex = user.Sex,
                              IsAdmin = user.IsAdmin,
                              Email = user.Email,
                              CreatedDate = user.CreatedDate,
                              AddedById = user.AddedById,                              
                              assigned_Dtos = (from r in _context.EmployeeAssignedReviews.Include(x=>x.ToBeReviewed).AsEnumerable()
                                     where r.ReviewerId == user.Id
                                     select new Assigned_dto
                                     { 
                                         UserId = r.ToBeReviewedId == null ?
                                                          Guid.Empty : r.ToBeReviewedId,
                                         UserFullName = r.ToBeReviewedId != null ?
                                                                r.ToBeReviewed.FirstName + " " + r.ToBeReviewed.LastName:
                                                                ""
                                     }).AsEnumerable()
                          }).AsEnumerable();

            return result;
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
                                                       x.ToBeReviewedId == employeeAssignedReview.GotReviewedId).Any())
                return "This record is already in database.";
            EmployeeAssignedReview newEmployeeAssigned = new EmployeeAssignedReview
            {
                Id = Guid.NewGuid(),
                AssignedById = employeeAssignedReview.AssignedById,
                ReviewerId = employeeAssignedReview.ReviewerId,
                ToBeReviewedId = employeeAssignedReview.GotReviewedId,
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
                                                       x.ToBeReviewedId == employeeAssignedReview.GotReviewedId).Any())
            {
                var toRemove = _context.EmployeeAssignedReviews.Where(x => x.ReviewerId == employeeAssignedReview.ReviewerId && x.ToBeReviewedId == employeeAssignedReview.GotReviewedId)?.First();
                _context.EmployeeAssignedReviews.Remove(toRemove);
                _context.SaveChanges();
                return "Successfully Removed";
            }
            return "This record is not present in database";

        }

        public object UpdateEmployeeForReview(EmployeeAssigned_dto employeeAssignedReview)
        {
            if (_context.EmployeeAssignedReviews.Where(x => x.ReviewerId == employeeAssignedReview.ReviewerId &&
                                                       x.ToBeReviewedId == employeeAssignedReview.GotReviewedId).Any())
                return "This record is already in database.";
            EmployeeAssignedReview employeeAssigned = new EmployeeAssignedReview
            {
                AssignedById = employeeAssignedReview.AssignedById,
                ReviewerId = employeeAssignedReview.ReviewerId,
                ToBeReviewedId = employeeAssignedReview.GotReviewedId,
                AssignedDate = DateTime.Now
            };
            _context.EmployeeAssignedReviews.Attach(employeeAssigned);
            _context.EmployeeAssignedReviews.Update(employeeAssigned);
            _context.Entry(employeeAssigned).State = EntityState.Modified;
            _context.SaveChanges();
            return employeeAssigned;
        }

        public Users UpdateUser(User_dto user)
        {
            var res = _context.Users.Where(x => x.Id == user.Id).First();
            res.FirstName = user.FirstName;
            res.LastName = user.LastName;
            res.IsAdmin = user.IsAdmin;
            res.Age = user.Age;
            res.Sex = user.Sex;
            res.Email = user.Email;
            res.CreatedDate = DateTime.Today;

            //_context.Users.Attach(userEntity);
            _context.Users.Update(res);
            _context.Entry<Users>(res).State = EntityState.Modified;
            _context.SaveChanges();
            return res;
        }
    }
}
