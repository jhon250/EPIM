using CommunityToolkit.Mvvm.Input;
using MateoPumacahua.FireBase;
using MateoPumacahua.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MateoPumacahua.ViewModel.Admin
{
    public class AddStudent : BaseViewModel
    {
        // instaciamos el crud alumnos
        AlumnosDataFB AlumnosFB = new AlumnosDataFB();


        // Atributos
        #region

        public String _IdeAlumno;
        public int _Ide;
        public string _Password;
        public string _Name;
        public string _SurName;
        public String _SecondName;
        public object _Grado1;
        public string GradoALVM;
        public string SeccionALVM; 

        #endregion


        // Propiedades
        #region Propiedades
        public String IdeAlumno
        {
            get { return this._IdeAlumno; }
            set { SetValue(ref this._IdeAlumno, value); }
        }

        public int Ide
        {
            get { return this._Ide; }
            set { SetValue(ref this._Ide, value); }
        }

        public string Password
        {
            get { return this._Password; }
            set { SetValue(ref this._Password, value); }
        }

        public string Name
        {
            get { return this._Name; }
            set { SetValue(ref this._Name, value); }
        }

        public string SurName
        {
            get { return this._SurName; }
            set { SetValue(ref this._SurName, value); }
        }

        public string SecondName
        {
            get { return this._SecondName; }
            set { SetValue(ref this._SecondName, value); }
        }

        public object Grado1
        {
            get { return this._Grado1; }
            set { SetValue(ref this._Grado1, value); }
        }

        // object
        public string ResultGrado
        {
            get { return this.GradoALVM; }
            set { SetValue(ref this.GradoALVM, value); }
        }

        public string ResultSeccion
        {
            get { return this.SeccionALVM; }
            set { SetValue(ref this.SeccionALVM, value); }
        }


        #endregion


        // comando del boton Añadir alumno
        public ICommand AñadirAlumnoGUI
        {
            get
            {
                // llamamos al metodo Inicio Sesion cuando
                // presione el boton
                return new RelayCommand(insertarAlumno);
            }
        }



        // ingreso de datos del adminstrador
        public async void insertarAlumno()
        {

            var Alumnos = new Alumno()
            {
                IdeAlumno = IdeAlumno,
                Ide = Ide,
                Password = Password,
                Name = Name,
                SurName = SurName,
                SecondName = SecondName,
            };

            var cursoAlumno = new Cursos()
            {
                Matematica = "",
            };
            
            var GradoAlumno = new Grado()
            {
                Seccion = SeccionALVM,
                Profesor = "",
                Curso =cursoAlumno,
            };


            await AlumnosFB.AgregarDatosAlumno(Alumnos, GradoAlumno);

            LimpiarEntry();


        }


        public void LimpiarEntry()
        {
            Ide = 0;
            IdeAlumno = "";
            Password = "";
            Name = "";
            SurName = "";
            SecondName = "";
            ResultGrado = "";
            ResultSeccion = "";
        }

    }
}
