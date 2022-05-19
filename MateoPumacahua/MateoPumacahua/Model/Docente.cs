using System;
using System.Collections.Generic;
using System.Text;

namespace MateoPumacahua.Model
{
    public class Docente
    {
        public string IdeDocente { get; set; }
        public int Ide { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string SecondName { get; set; }
        public string Materia { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; }
        public Grado Grado1 { get; set; }
        

    }
}
