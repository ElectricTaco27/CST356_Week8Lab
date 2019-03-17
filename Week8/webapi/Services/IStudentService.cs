using System.Collections.Generic;
using Database.Entities;

public interface IStudentService
{
    List<StudentDto> GetAllStudents();

    Student GetStudentById(long studentId);

    void AddStudent(Student student);

    void UpdateStudent(Student student);

    void DeleteStudent(long studentId);
}