namespace MySchool.Domain.Entities
{
    public class Person : BasicEntity
    {
        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string FullName => FirstName + ", " + LastName;
    }
}