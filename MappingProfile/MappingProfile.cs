using AutoMapper;
using CodingTest.API_Result;
using CodingTest.Models;

namespace CodingTest.MappingProfile
{
    /// <summary>
    /// This class purpose is to create mapping profile
    /// between our domain Model and  data transfer objects
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, User_dto>().ForMember(src => src.FullName,
                options => options.MapFrom(dest => dest.FirstName + " " + dest.LastName));
            CreateMap<EmployeeAssignedReview, EmployeeAssigned_dto>();
            CreateMap<Review, Review_dto>().ForMember(x => x.ReviewerName,
                options => options.MapFrom(src => src.Reviewer.FirstName + " " + src.Reviewer.LastName))
                .ForMember(dest => dest.GotReviewedName,
                options => options.MapFrom(src => src.GotReviewed.FirstName + " " + src.GotReviewed.LastName));
        }
    }
}
