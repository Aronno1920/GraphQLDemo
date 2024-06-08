using Bogus;
using GraphQLDemo.API.Domain.Common;
using GraphQLDemo.API.Schema.Instructors;
using GraphQLDemo.API.Schema.Students;

namespace GraphQLDemo.API.Schema.Courses.Query
{
    public class CourseQuery
    {
        private readonly Faker<InstructorDTO> instructorFaker;
        private readonly Faker<StudentDTO> studentFacker;
        private readonly Faker<CourseType> courseFaker;

        public CourseQuery()
        {
            instructorFaker = new Faker<InstructorDTO>()
                .RuleFor(c => c.Id, d => Guid.NewGuid())
                .RuleFor(c => c.FirstName, d => d.Name.FindName())
                .RuleFor(c => c.LastName, d => d.Name.LastName())
                .RuleFor(c => c.Salary, d => d.Random.Double(0, 1000000));

            studentFacker = new Faker<StudentDTO>()
                .RuleFor(c => c.Id, d => Guid.NewGuid())
                .RuleFor(c => c.FirstName, d => d.Name.FindName())
                .RuleFor(c => c.LastName, d => d.Name.LastName())
                .RuleFor(c => c.GPA, d => d.Random.Double(1, 4));

            courseFaker = new Faker<CourseType>()
                .RuleFor(c => c.Id, d => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Name.JobTitle())
                .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
                .RuleFor(c => c.Instructor, f => instructorFaker.Generate())
                .RuleFor(c => c.Students, f => studentFacker.Generate(10));
        }


        public IEnumerable<CourseType> GetCourses()
        {
            List<CourseType> courses = courseFaker.Generate(5);

            return courses;
        }

        public CourseType GetCourseById(Guid Id)
        {
            CourseType course = courseFaker.Generate();
            course.Id = Id;

            return course;
        }




        [GraphQLDeprecated("The message is deprecated")]
        public string welcomenote => "Welcome to GraphQL Demo project";
    }
}
