using GraphQLDemo.API.Schema.Instructors;


namespace GraphQLDemo.API.Schema.Courses.Mutation
{
    public class CourseMutation
    {
        private readonly List<CourseResult> _courses;

        public CourseMutation()
        {
            _courses = new List<CourseResult>();
        }

        public CourseResult CreateCourse(CourseInput courseInput)
        {
            CourseResult course = new CourseResult()
            {
                Id = Guid.NewGuid(),
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId
            };

            _courses.Add(course);
            return course;
        }

        public CourseResult UpdateCourse(Guid courseId, CourseInput courseInput)
        {
            CourseResult course = _courses.FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                throw new GraphQLException(new Error("Course not found", "NotFound"));
            }
            else
            {
                course.Name = courseInput.Name;
                course.Subject = courseInput.Subject;
                course.InstructorId = courseInput.InstructorId;
            }

            return course;
        }

        public bool DeleteCourse(Guid courseId)
        {
            return _courses.RemoveAll(c => c.Id == courseId) >= 1;
        }

    }
}
