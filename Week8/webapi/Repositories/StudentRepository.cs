using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Database;
using System;
using Database.Entities;

public class StudentRepository : IStudentRepository
{
    private readonly SchoolContext _dbContext;
    private readonly ILogger _logger;

    public StudentRepository(SchoolContext _dbContext, ILoggerFactory loggerFactory)
    {
        this._dbContext = _dbContext;
        this._logger = loggerFactory.CreateLogger("Controllers.StudentRepository");
    }

    public List<Student> GetAllStudents()
    {
        try
        {
            return _dbContext.Student.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to get students.", ex);
            return new List<Student>();
        }
    }

    public Student GetStudentById(long studentId)
    {
        return _dbContext.Student.SingleOrDefault(s => s.StudentId == studentId);
    }

    public void AddStudent(Student student)
    {
        _dbContext.Student.Add(student);
        _dbContext.SaveChanges();
    }

    public void UpdateStudent(Student studentUpdate)
    {
        var student = GetStudentById(studentUpdate.StudentId);
        if (student != null)
        {
            student.StudentId = studentUpdate.StudentId;
            student.Email = studentUpdate.Email;
            _dbContext.Update(student);
            _dbContext.SaveChanges();
        }
    }

    public void DeleteStudent(long studentId)
    {
        var student = GetStudentById(studentId);
        _dbContext.Remove(student);
        _dbContext.SaveChanges();

        // var product = new Product { ProductId = productId };
        // _dbContext.Product.Attach(product);
        // _dbContext.Product.Remove(product);
        // _dbContext.SaveChanges();
    }
}