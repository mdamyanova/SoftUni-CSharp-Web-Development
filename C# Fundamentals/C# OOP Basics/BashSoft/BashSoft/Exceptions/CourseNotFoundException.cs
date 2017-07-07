using System;

namespace BashSoft.Exceptions
{
    public class CourseNotFoundException : Exception
    {
        private const string CourseNotFound = "Course is not found.";

        public CourseNotFoundException() : base(CourseNotFound)
        {
            
        }

        public CourseNotFoundException(string message) : base(message)
        {
            
        }
    }
}