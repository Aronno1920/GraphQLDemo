using GraphQLDemo.API.Schema.Instructors;


namespace GraphQLDemo.API.Schema.Courses
{
    public class CourseMutation
    {
        private readonly List<CourseType> _courses;

        public CourseMutation()
        {
            _courses = new List<CourseType>();
        }

        public bool CreateCourse(string name, Subject subject, Guid instructorId)
        {
            CourseType course = new CourseType()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Subject = subject,
                Instructor = new InstructorType
                {
                    Id = instructorId
                }
            };

            _courses.Add(course);
            return true;
        }
    }
}
