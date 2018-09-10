using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MySchool.Models;

namespace MySchool.Controllers
{
    public class HomeController : Controller
    {
        //private readonly MySchoolContext _context;

        //public HomeController(MySchoolContext context)
        //{
        //    _context = context;
        //}

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> About()
        //{
        //    var groups = new List<EnrollmentDateGroup>();

        //    var conn = _context.Database.GetDbConnection();

        //    try
        //    {
        //        await conn.OpenAsync();
        //        using (var command = conn.CreateCommand())
        //        {
        //            const string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
        //                                 + "FROM Person "
        //                                 + "WHERE Discriminator = 'Student' "
        //                                 + "GROUP BY EnrollmentDate";

        //            command.CommandText = query;

        //            var reader = await command.ExecuteReaderAsync();

        //            if (reader.HasRows)
        //            {
        //                while (await reader.ReadAsync())
        //                {
        //                    var row = new EnrollmentDateGroup { EnrollmentDate = reader.GetDateTime(0), StudentCount = reader.GetInt32(1) };
        //                    groups.Add(row);
        //                }
        //            }
        //            reader.Dispose();
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return View(groups);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}