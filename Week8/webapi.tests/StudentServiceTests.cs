using NUnit.Framework;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Database.Entities;
using System.Linq;
using FluentAssertions;
using StudentBusinessRules;

public class StudentServiceTests
{
    private StudentService _studentService;
    private IStudentRepository _studentRepository;

    [SetUp]
    public void Setup(){
        var loggerFactory = A.Fake<LoggerFactory>();
        _studentRepository = A.Fake<IStudentRepository>();
        _studentService = new StudentService(_studentRepository, loggerFactory);
    }

    [Test]
    public void IsEduEmailTest_ShouldReturnTrueGivenEduEmail_ShouldPass()
    {
        // Arrange
        A.CallTo(() => _studentRepository.GetAllStudents()).Returns(
            new List<Student> {
                new Student {
                    StudentId = 1,
                    Email = "riggs.burnham@oit.edu"
                },
                new Student {
                    StudentId = 2,
                    Email = "asuna.yuuki@sao.edu"
                }
            }
        );

        // Act
        var studentDtos = _studentService.GetAllStudents();

        // Assert
        Assert.That(studentDtos.Any(sdto => sdto.EduEmail), Is.EqualTo(true));
    }

    [Test]
    public void IsEduEmailTest_ShouldReturnFalseGivenInvalidEmail_ShouldPass()
    {
        // Arrange
        A.CallTo(() => _studentRepository.GetAllStudents()).Returns(
            new List<Student> {
                new Student {
                    StudentId = 1,
                    Email = "riggs1243@gmail.com"
                },
                new Student {
                    StudentId = 2,
                    Email = "asuna.yuuki@sao.net"
                }
            }
        );

        // Act
        var studentDtos = _studentService.GetAllStudents();

        // Assert
        studentDtos.Any(pdto => pdto.EduEmail).Should().BeFalse();
        //Assert.IsFalse(result, "Should pass if the studentDtos[1] has a invalid email extension (extension != .edu)");
    }
}