using Microsoft.EntityFrameworkCore;

namespace MySchool.Infrastructure.Contexts
{
    public class MySchoolContext : DbContext
    {
        public MySchoolContext(DbContextOptions<MySchoolContext> options) : base(options) { }
    }
}
