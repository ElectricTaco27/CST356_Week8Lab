using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //private readonly SchoolContext _dbContext;
        private readonly IStudentService _studentService;
        private readonly ILogger _logger;

        public StudentController(IStudentService studentService, ILoggerFactory loggerFactory)
        {
            this._studentService = studentService;
            this._logger = loggerFactory.CreateLogger("Controllers.StudentController");
        }

        [HttpGet]
        public ActionResult<List<StudentDto>> GetAllStudents()
        {
            _logger.LogDebug("Getting all students");
            //return Ok(_dbContext.Student.Include(s => s.Person).ToList());
            return _studentService.GetAllStudents();
        }

        [HttpGet("{studentId}")]
        public ActionResult<Student> GetStudent(int studentId)
        {
            var student = _studentService.GetStudentById(studentId);

            if (student != null) {
                return student;
            } else {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            _studentService.AddStudent(student);

            // return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);

            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created);
        }

        [HttpDelete("{studentId}")]
        public ActionResult DeleteStudent(int studentId)
        {
            _studentService.DeleteStudent(studentId);

            return Ok();
        }

        [HttpPut("{studentId}")]
        public ActionResult UpdateStudent(int studentId, Student studentUpdate)
        {
            studentUpdate.StudentId = studentId;
            _studentService.UpdateStudent(studentUpdate);

            return NoContent();
        }
    }
}