using System;
using Database.Entities;

namespace StudentBusinessRules {
    public static class BusinessRules
    {
        public static bool IsEduEmail(Student student)
        {
            string[] contents = student.Email.Split('.');
            string extension = contents[contents.Length-1];
            if (extension == "edu")
            {
                return true;
            }
            else
            {
                return false;
            }   
        }
    }
}