using GraphQLDemo.API.Schema.Courses.Mutation;
using GraphQLDemo.API.Schema.Courses.Query;
using GraphQLDemo.API.Schema.Courses.Subscription;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<CourseQuery>()
    .AddMutationType<CourseMutation>()
    .AddSubscriptionType<CourseSubscription>()
    .AddInMemorySubscriptions();





var app = builder.Build();

app.UseRouting();
app.UseWebSockets();
app.MapGraphQL();

app.Run();
