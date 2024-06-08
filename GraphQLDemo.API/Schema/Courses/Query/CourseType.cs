using GraphQLDemo.API.Domain.Common;
using GraphQLDemo.API.Schema.Instructors;
using GraphQLDemo.API.Schema.Students;

namespace GraphQLDemo.API.Schema.Courses.Query
{
    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }

        [GraphQLNonNullType]
        public InstructorDTO Instructor { get; set; }
        public IEnumerable<StudentDTO> Students { get; set; }
    }
}
