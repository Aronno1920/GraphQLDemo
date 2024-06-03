namespace GraphQLDemo.API.Schema
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
