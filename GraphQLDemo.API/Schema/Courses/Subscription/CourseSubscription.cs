using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using GraphQLDemo.API.Schema.Courses.Mutation;

namespace GraphQLDemo.API.Schema.Courses.Subscription
{
    public class CourseSubscription
    {
        [Subscribe]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;

        [SubscribeAndResolve]
        public ValueTask<ISourceStream<CourseResult>> CourseUpdated(Guid courseId, [Service] ITopicEventReceiver eventReceiver)
        {
            string topicName = $"{courseId}_{nameof(CourseSubscription.CourseUpdated)}";
            return eventReceiver.SubscribeAsync<CourseResult>(topicName);
        }
    }
}
