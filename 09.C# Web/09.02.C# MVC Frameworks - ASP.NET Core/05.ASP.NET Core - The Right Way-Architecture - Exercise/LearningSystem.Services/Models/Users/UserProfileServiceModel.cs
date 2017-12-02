namespace LearningSystem.Services.Models.Users
{
    using AutoMapper;
    using Core.Mapping;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserProfileServiceModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public IEnumerable<UserProfileCourseServiceModel> Courses { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                 .CreateMap<User, UserProfileServiceModel>()
                 .ForMember(u => u.Courses, 
                     cfg => cfg.MapFrom(s => s.Courses.Select(c => c.Course)));
    }
}