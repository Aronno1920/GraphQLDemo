namespace GraphQLDemo.API.Schema.Courses
{
    public class CourseResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
