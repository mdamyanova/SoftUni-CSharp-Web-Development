namespace LearningSystem.Services.Models
{
    using AutoMapper;
    using Core.Mapping;
    using Data.Models;
    using System;
    using System.Linq;

    public class CourseDetailsServiceModel : IMapFrom<Course>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Trainer { get; set; }

        public int Students { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Course, CourseDetailsServiceModel>()
                .ForMember(c => c.Trainer, cfg => cfg.MapFrom(c => c.Trainer.UserName))
                .ForMember(c => c.Students, cfg => cfg.MapFrom(c => c.Students.Count()));
    }
}