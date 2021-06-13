using AutoMapper;
using CodingTest.API_Result;
using CodingTest.EF_Operation;
using CodingTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<Users>
    {
        IUserRepository _userRepository;
        IMapper _mapper;
        public UserController(IGenericRepository<Users> repository, IUserRepository userRepository, IMapper mapper) : base(repository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAllUsers")]
        //[Authorize("Admin,User")]
        public IActionResult GetAllUsers()
        {
            var res = _userRepository.GetAllUsers();
            return Ok(res);
        }

        [HttpGet]
        [Route("getEmployeeAssignedToMe/{id}")]
        //[Authorize("Admin,User")]
        public IActionResult GetEmployeeAssignedToMe(Guid id)
        {
            var res = _userRepository.GetEmployeeAssignedToMe(id);
            return Ok(_mapper.Map<List<EmployeeAssignedReview>, List<EmployeeAssigned_dto>>(res.ToList()));
        }

        [HttpGet]
        [Route("getAllAssignedEmployee")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetAllEmployeeAssigned()
        {
            var res = _userRepository.GetAllEmployeeForReview();
            var x = _mapper.Map<List<EmployeeAssignedReview>, List<EmployeeAssigned_dto>>(res.ToList());
            return Ok(x);
        }

        [HttpPut]
        [Route("updateUser")]
        //[Authorize("Admin")]
        public IActionResult UpdateUser([FromBody] User_dto user)
        {
            var res = _userRepository.UpdateUser(user);
            return Ok(_mapper.Map<Users, User_dto>(res));
        }

        [HttpPost]
        [Route("assignEmployeeForReview")]
        //[Authorize("Admin")]
        public IActionResult AssignEmployeeForReview([FromBody] EmployeeAssigned_dto record)
        {
            var res = _userRepository.AssignEmployeeForReview(record);
            return Ok(res);
        }

        [HttpPut]
        [Route("updateAssignedEmployee")]
        //[Authorize("Admin")]
        public IActionResult Update([FromBody] EmployeeAssigned_dto record)
        {
            var res = _userRepository.UpdateEmployeeForReview(record);
            return Ok(res);
        }

        [HttpDelete]
        [Route("removeFromAssigned")]
        //[Authorize("Admin")]
        public IActionResult Delete([FromBody] EmployeeAssigned_dto record)
        {
            var res = _userRepository.RemoveEmployeeForReview(record);
            return Ok(res);
        }
    }
}
