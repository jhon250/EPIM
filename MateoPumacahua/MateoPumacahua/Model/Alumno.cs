using System;
using System.Collections.Generic;
using System.Text;

namespace MateoPumacahua.Model
{
    public class Alumno
    {
        public string IdeAlumno { get; set; }
        public int Ide { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string SecondName { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; }
        public Grado Grado { get; set; }
        //public Grado Grado2 { get; set; }
        //public Grado Grado3 { get; set; }
        //public Grado Grado4 { get; set; }
        //public Grado Grado5 { get; set; }

        
    }

    public class Grado
    {
        public string Grados { get; set; }
        public string IdeDocenteG { get; set; }
        public string Seccion { get; set; }
        public Course Cursoss { get; set; }
        //public Course Curso_2 { get; set; }
        //public Course Curso_3 { get; set; }
        //public Course Curso_4 { get; set; }
        //public Course Curso_5 { get; set; }
        //public Course Curso_6 { get; set; }
        //public Course Curso_7 { get; set; }
        //public Course Curso_8 { get; set; }
        //public Course Curso_9 { get; set; }
        //public Course Curso_10 { get; set; }
        //public Course Curso_11 { get; set; }
        //public Course Curso_12 { get; set; }
        //public Course Curso_13 { get; set; }
        //public Course Curso_14 { get; set; }
        //public Course Curso_15 { get; set; }

    }

    public class Course
    {
        public string IdeCurso { get; set; }
        public string Curso { get; set; }
        public string IdeDocenteC { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public Day Meses_dia { get; set; }
        //public Day Mes_2 { get; set; }
        //public Day Mes_3 { get; set; }
        //public Day Mes_4 { get; set; }
        //public Day Mes_5 { get; set; }
        //public Day Mes_6 { get; set; }
        //public Day Mes_7 { get; set; }
        //public Day Mes_8 { get; set; }
        //public Day Mes_9 { get; set; }
        //public Day Mes_10 { get; set; }
        //public Day Mes_11 { get; set; }
        //public Day Mes_12 { get; set; }

        //public Month Mes_1 { get; set; }
        //public Month Mes_2 { get; set; }
        //public Month Mes_3 { get; set; }
        //public Month Mes_4 { get; set; }
        //public Month Mes_5 { get; set; }
        //public Month Mes_6 { get; set; }
        //public Month Mes_7 { get; set; }
        //public Month Mes_8 { get; set; }
        //public Month Mes_9 { get; set; }
        //public Month Mes_10 { get; set; }
        //public Month Mes_11 { get; set; }
        //public Month Mes_12 { get; set; }
    }
     
}
