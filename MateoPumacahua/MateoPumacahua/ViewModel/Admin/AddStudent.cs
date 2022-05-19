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

        
        public int _Ide;
        public string _Password;
        public string _Name;
        public string _SurName;
        public string _SecondName;
        public string _Correo;
        public object _Grado1;
        public string GeneroALVM;
        public string GradoALVM;
        public string SeccionALVM; 

        #endregion


        // Propiedades
        #region Propiedades
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

        public string Correo
        {
            get { return this._Correo; }
            set { SetValue(ref this._Correo, value); }
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

        public string ResultGenero
        {
            get { return this.GeneroALVM; }
            set { SetValue(ref this.GeneroALVM, value); }
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
            //var dia = new Day() { };
            var curso = new Course() { };
            var GradoAlumno = new Grado()
            {
                Grados = ResultGrado,
                Seccion = ResultSeccion,
                IdeDocenteG = "",
                Cursoss = curso,
            };

            var Alumnos = new Alumno()
            {
                Ide = Ide,
                Password = Password,
                Name = Name,
                SurName = SurName,
                SecondName = SecondName,
                Correo = Correo,
                Genero = ResultGenero,    
            };

            await AlumnosFB.AgregarDatosAlumno(Alumnos, GradoAlumno);

            LimpiarEntry();


        }

        //private void Grado_elect(string Grado)
        //{
        //    if (Grado == "Grado 1")
        //    {
        //        var Alumnos = new Alumno()
        //        {

        //            Ide = Ide,
        //            Password = Password,
        //            Name = Name,
        //            SurName = SurName,
        //            SecondName = SecondName,
        //            Correo = Correo,
        //            Genero = ResultGenero,
        //            Grado = GradoAlumno,
        //        };
        //        var GradoAlumno = new Grado()
        //        {
        //            Seccion = ResultSeccion,
        //            IdeDocenteG = "",
        //            Cursoss = curso,
        //        };
        //        var curso = new Course() { };
                
        //    }
        //}


        public void LimpiarEntry()
        {
            Ide = 0;
            Password = "";
            Name = "";
            SurName = "";
            SecondName = "";
            Correo = "";
            ResultGrado = "";
            ResultSeccion = "";
            ResultGenero = "";
        }

    }
}
