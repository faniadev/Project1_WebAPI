using AutoMapper;
using Project1_WebAPI.Dtos;
using Project1_WebAPI.Models;

namespace Project1_WebAPI.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Course, CourseDto>();

            CreateMap<CourseForCreateDto, Course>();
   
        }
    }
}