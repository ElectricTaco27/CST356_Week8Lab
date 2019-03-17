using System.Collections.Generic;
using Database;
using Database.Entities;

public interface IStudentRepository
{
    List<Student> GetAllStudents();
    Student GetStudentById(long studentId);

    void AddStudent(Student student);

    void UpdateStudent(Student student);

    void DeleteStudent(long studentId);
}