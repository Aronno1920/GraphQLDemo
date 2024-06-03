using System.Transactions;

namespace GraphQLDemo.API.Schema
{
    public class StudentType
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [GraphQLName("gpa")]
        public double GPA { get; set; }
    }
}
