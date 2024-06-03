using Bogus;

namespace GraphQLDemo.API.Schema
{
    public class Query
    {
        public IEnumerable<CourseType> GetCourcess()
        {
            Faker<InstructorType> instructorFaker = new Faker<InstructorType>()
                .RuleFor(c => c.Id, d => Guid.NewGuid())
                .RuleFor(c => c.FirstName, d => d.Name.FindName())
                .RuleFor(c => c.LastName, d => d.Name.LastName())
                .RuleFor(c => c.Salary, d => d.Random.Double(0, 1000000));

            Faker<StudentType> studentFacker = new Faker<StudentType>()
                .RuleFor(c => c.Id, d => Guid.NewGuid())
                .RuleFor(c => c.FirstName, d => d.Name.FindName())
                .RuleFor(c => c.LastName, d => d.Name.LastName())
                .RuleFor(c => c.GPA, d => d.Random.Double(1, 4));


            Faker<CourseType> courseFaker = new Faker<CourseType>();
            courseFaker.RuleFor(c => c.Id, d => Guid.NewGuid());
            courseFaker.RuleFor(c => c.Name, f => f.Name.JobTitle());
            courseFaker.RuleFor(c => c.Subject, f => f.PickRandom<Subject>());
            courseFaker.RuleFor(c => c.Instructor, f => instructorFaker.Generate());

            List<CourseType> courses = courseFaker.Generate(5);
            return courses;
        }

        [GraphQLDeprecated("The message is deprecated")]
        public String welcomenote => "Welcome to GraphQL Demo project";
    }
}
