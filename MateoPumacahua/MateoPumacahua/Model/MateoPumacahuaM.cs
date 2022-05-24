using System;
using System.Collections.Generic;
using System.Text;

namespace MateoPumacahua.Model
{
    public class MateoPumacahuaM
    {

    }

    public class ListView_student_template
    {
        public string KeyUsers { get; set; }
        public string KeyCourse { get; set; }
        public string Keyday { get; set; }
        public string Name { get; set; }   
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
        public string Materia { get; set; }
        public string Present { get; set; }
        public string Delay { get; set; }
        public string Absent { get; set; }

    }

    public class User_template
    {
        public string KeyUser { get; set; }
        public string Ide { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; } 
        public string Phone { get; set; }   
        public string Grado { get; set; }
        public string Seccion { get; set; }
        public string Materia { get; set; }
        public Teacher_template Teacher { get; set; }
        public string IdeCourse { get; set; }
        
        //public Student_History_Template History { get; set; } 
    }

    public class Info_Users_Template
    {
        public string KeyData{ get; set; } 
        public string IdeStudent { get; set; }
        public string IdeTeacher { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Extras { get; set; }  
        
    }

    public class Day_template
    {
        public string Ides { get; set; }
        public string Present { get; set; }
        public string Delay { get; set; }
        public string Absent { get; set; }
    }
    public class Teacher_template
    {
        public string Materia { get; set; }
        public string Grado{ get; set; }
        public string Seccion { get; set; }


    }

}
