using GraphQLDemo.API.Schema.Courses.Mutation;
using GraphQLDemo.API.Schema.Courses.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<CourseQuery>()
    .AddMutationType<CourseMutation>();

var app = builder.Build();

app.MapGraphQL();
app.Run();
