using System.Collections.Generic;
using Database.Entities;
using Microsoft.Extensions.Logging;
using StudentBusinessRules;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILogger _logger;

    public StudentService(IStudentRepository studentRepository, ILoggerFactory loggerFactory)
    {
        this._studentRepository = studentRepository;
        this._logger = loggerFactory.CreateLogger("Controllers.StudentService");
    }

    public List<StudentDto> GetAllStudents()
    {
        var studentDtos = new List<StudentDto>();
        foreach(var student in _studentRepository.GetAllStudents())
        {
            studentDtos.Add(new StudentDto {
                StudentId = student.StudentId,
                Email = student.Email,
                EduEmail = BusinessRules.IsEduEmail(student)
            });
            if (BusinessRules.IsEduEmail(student))
            {
                _logger.LogInformation("Found a .edu Email, This student is using the correct email: " + student.StudentId);
            }
        }
        return studentDtos;
    }

    public Student GetStudentById(long studentId)
    {
        return _studentRepository.GetStudentById(studentId);
    }

    public void AddStudent(Student student)
    {
        _studentRepository.AddStudent(student);
    }

    public void UpdateStudent(Student student)
    {
        _studentRepository.UpdateStudent(student);
    }

    public void DeleteStudent(long studentId)
    {
        _studentRepository.DeleteStudent(studentId);
    }  
}