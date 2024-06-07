﻿using GraphQLDemo.API.Schema.Courses.Query;

namespace GraphQLDemo.API.Schema.Courses.Mutation
{
    public class CourseInput
    {
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
