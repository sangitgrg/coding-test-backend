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
    public class ReviewController : BaseController<Review>
    {
        IReviewRepository _reviewRepository;
        IMapper _mapper;
        public ReviewController(IGenericRepository<Review> repository, IReviewRepository reviewRepository, IMapper mapper) : base(repository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAllReviews")]
        //[Authorize("Admin,User")]
        public IActionResult GetAllReviewInformation()
        {
            var res = _reviewRepository.GetAllReviewInformation();
            return Ok(_mapper.Map<List<Review>, List<Review_dto>>(res.ToList()));
        }

        [HttpGet]
        [Route("getReviewsAssignedToMe/{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetOnlyAssignedReview(Guid id)
        {
            var res = _reviewRepository.GetOnlyAssignedReview(id);
            var x = _mapper.Map<List<Review>, List<Review_dto>>(res.ToList());
            return Ok(x);
        }

    }
}
