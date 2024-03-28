using Lab4Web.Services.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLinqController : ControllerBase
    {
        private readonly ILinqService _linqService;

        public TestLinqController(ILinqService linqService)
        {
            _linqService = linqService;
        }

        [HttpGet("test-1")]
        public int Get(int age)
        {
            
            return _linqService.Test1(age);
        }

        [HttpGet("test-2")]
        public List<Student> ActiveStudents()
        {
            var activeStudents = Database.Students.Where(s => s.Active).ToList();
            Console.WriteLine("Number of active students: " + activeStudents.Count);
            return activeStudents;
        }

        [HttpGet("test-3")]
        public List<string> StudentNames()
        {
            var studentNames = Database.Students.Select(s => s.Name).ToList();
            return studentNames;
        }

        [HttpGet("test-4")]
        public int StudentsCount()
        {
            var studentsCount = Database.Students.Count;
            return studentsCount;
        }

        [HttpGet("test-5")]
        public List<Student> Query1()
        {
            var methodBasedQuery = Database.Students.Where(s => s.Active).ToList();

            return methodBasedQuery;
        }

        [HttpGet("test-6")]
        public IEnumerable<StudentCourse> Query2()
        {
            var queryWithJoin = from student in Database.Students
                                join course in Courses.CourseList on student.Id equals course.StudentId
                                where (course.Name == "TAP")
                                select new StudentCourse
                                {
                                    StudentName = student.Name,
                                    CourseName = course.Name
                                };

            return queryWithJoin.ToList();
        }

        [HttpGet("test-7")]
        public List<GroupInfo> QueryGroup()
        {
            var groupedStudents = from student in Database.Students
                                  group student by student.Group into studentGroup
                                  select new GroupInfo
                                  {
                                      GroupName = studentGroup.Key,
                                      StudentCount = studentGroup.Count(),
                                      Students = studentGroup.ToList()
                                  };

            return groupedStudents.ToList();
        }


    }
}
