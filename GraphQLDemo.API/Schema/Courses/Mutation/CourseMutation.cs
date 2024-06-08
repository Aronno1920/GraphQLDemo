using GraphQLDemo.API.Schema.Courses.Subscription;
using GraphQLDemo.API.Schema.Instructors;
using HotChocolate.Subscriptions;


namespace GraphQLDemo.API.Schema.Courses.Mutation
{
    public class CourseMutation
    {
        private readonly List<CourseResult> _courses;

        public CourseMutation()
        {
            _courses = new List<CourseResult>();
        }

        public async Task<CourseResult> CreateCourse(CourseInput courseInput, [Service] ITopicEventSender eventSender)
        {
            CourseResult course = new CourseResult()
            {
                Id = Guid.NewGuid(),
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId
            };

            _courses.Add(course);
            await eventSender.SendAsync(nameof(CourseSubscription.CourseCreated), course);

            return course;
        }

        public async Task<CourseResult> UpdateCourse(Guid courseId, CourseInput courseInput, [Service] ITopicEventSender eventSender)
        {
            CourseResult course = _courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                throw new GraphQLException(new Error("Course not found", "NotFound"));
            }

            course.Name = courseInput.Name;
            course.Subject = courseInput.Subject;
            course.InstructorId = courseInput.InstructorId;

            string topicName = $"{course.Id}_{nameof(CourseSubscription.CourseUpdated)}";
            await eventSender.SendAsync(topicName, course);

            return course;
        }

        public bool DeleteCourse(Guid courseId)
        {
            return _courses.RemoveAll(c => c.Id == courseId) >= 1;
        }

    }
}
