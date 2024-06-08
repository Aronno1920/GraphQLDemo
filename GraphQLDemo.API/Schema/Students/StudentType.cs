using System.Transactions;

namespace GraphQLDemo.API.Schema.Students
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [GraphQLName("gpa")]
        public double GPA { get; set; }
    }
}
