using EmployeeService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Tonmoy"},
            new Student() { Id = 2, Name = "Tinny"},
            new Student() { Id = 3, Name = "Tony"}
        };

        [HttpGet]
        [Route("~/api/teachers")]
        public IEnumerable<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher() { Id = 1, Name ="Tomy"},
                new Teacher() { Id = 2, Name ="Moni"},
                new Teacher(){ Id = 3, Name ="Niloy"}
            };
            return teachers;
        }
        
        [HttpGet]
        [Route("")]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        [HttpGet]
        //[Route("api/students/{id}")]
        //[Route("{id:int:min(1):max(3)}")]
        [Route("{id:int:range(1, 3)}")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        [HttpGet]
        //[Route("api/students/{id}")]
        [Route("{name:alpha}")]
        public Student Get(string name)
        {
            return students.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        [HttpGet]
        //[Route("api/students/{id}/courses")]
        [Route("{id}/courses")]
        public IEnumerable<string>GetStudentCourses(int id)
        {
            if (id == 1)
                return new List<string>() { "C#", "ASP.NET", "SQL Server" };
            else if (id == 2)
                return new List<string>() { "ASP.NET Web API", "C++", "SQL Server" };
            else
                return new List<string>() { "Bootstrap", "jQuery", "AngularJs" }; 
        }
    }
}
