using GraphQLDemo.API.ApplicationContext;
using GraphQLDemo.API.Schema.Courses.Mutation;
using GraphQLDemo.API.Schema.Courses.Query;
using GraphQLDemo.API.Schema.Courses.Subscription;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPooledDbContextFactory<SchoolDbContext>(d => d.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")))
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
