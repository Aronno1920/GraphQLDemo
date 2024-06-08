using GraphQLDemo.API.ApplicationContext;
using GraphQLDemo.API.Schema.Courses.Mutation;
using GraphQLDemo.API.Schema.Courses.Query;
using GraphQLDemo.API.Schema.Courses.Subscription;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

//builder.Services
//    .AddGraphQLServer()
//    .AddQueryType<CourseQuery>()
//    .AddMutationType<CourseMutation>()
//    .AddSubscriptionType<CourseSubscription>()
//    .AddInMemorySubscriptions();

// Retrieve the connection string from appsettings.json
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddPooledDbContextFactory<SchoolDbContext>(d => d.UseSqlite(connectionString));


builder.Services
    .AddPooledDbContextFactory<SchoolDbContext>(d => d.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")))
    .AddGraphQLServer()
    .AddQueryType<CourseQuery>()
    .AddMutationType<CourseMutation>()
    .AddSubscriptionType<CourseSubscription>()
    .AddInMemorySubscriptions();

//builder.Services
//    .AddPooledDbContextFactory<SchoolDbContext>(options =>
//        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")))
//    .AddGraphQLServer()
//    .AddQueryType<CourseQuery>()
//    .AddMutationType<CourseMutation>()
//    .AddSubscriptionType<CourseSubscription>()
//    .AddInMemorySubscriptions()
//    .AddFiltering()
//    .AddSorting();


var app = builder.Build();

app.UseRouting();
app.UseWebSockets();
app.MapGraphQL();

app.Run();
