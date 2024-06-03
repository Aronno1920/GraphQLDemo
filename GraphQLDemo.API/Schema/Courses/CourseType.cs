using GraphQLDemo.API.Schema.Instructors;
using GraphQLDemo.API.Schema.Students;

namespace GraphQLDemo.API.Schema.Courses
{
    public enum Subject
    {
        Bangla,
        English,
        Nathmatices,
        Science,
        History
    }

    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public Subject Subject { get; set; }

        [GraphQLNonNullType]
        public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; }
    }
}
