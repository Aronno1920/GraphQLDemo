using GraphQLDemo.API.Schema.Courses;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<CourseQuery>()
    .AddMutationType<CourseMutation>();

var app = builder.Build();

app.MapGraphQL();
app.Run();
