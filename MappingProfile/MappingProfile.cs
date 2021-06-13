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
            CreateMap<EmployeeAssignedReview, EmployeeAssigned_dto>()
                .ForMember(src => src.GotReviewedId, opt => opt.MapFrom(dest => dest.ToBeReviewedId))
                .ForMember(src => src.ReviewerName,
                options => options.MapFrom(dest => dest.Reviewer.FirstName + " " + dest.Reviewer.LastName))
                .ForMember(src => src.GotReviewedName,
                options => options.MapFrom(dest => dest.ToBeReviewed.FirstName + " " + dest.ToBeReviewed.LastName))
                .ForMember(src => src.AssignedByName,
                options => options.MapFrom(dest => dest.AssignedBy.FirstName + " " + dest.AssignedBy.LastName));
            CreateMap<Users, User_dto>().ForMember(src => src.FullName,
                options => options.MapFrom(dest => dest.FirstName + " " + dest.LastName))
                .ForMember(src=>src.EmployeeToBeReviewed,
                opt=>opt.MapFrom(dest=>dest.EmployeeToBeReviewed));
            CreateMap<Review, Review_dto>().ForMember(src => src.ReviewerName,
                options => options.MapFrom(dest => dest.Reviewer.FirstName + " " + dest.Reviewer.LastName))
                .ForMember(src=>src.GotReviewedName,
                opt => opt.MapFrom(dest => dest.GotReviewed.FirstName + " " + dest.GotReviewed.LastName));            
        }
    }
}
