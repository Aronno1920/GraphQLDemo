namespace GraphQLDemo.API.Schema
{
    public class Query
    {
        [GraphQLDeprecated("The message is deprecated")]
        public String welcomenote => "Welcome to GraphQL Demo project";
    }
}
