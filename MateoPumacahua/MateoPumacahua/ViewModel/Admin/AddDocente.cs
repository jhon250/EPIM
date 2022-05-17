using MateoPumacahua.FireBase;
using MateoPumacahua.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MateoPumacahua.ViewModel.Admin
{
    public class AddDocente : BaseViewModel
    {

        // instaciamos el crud alumnos
        DocenteDataFB DocenteFB = new DocenteDataFB();


        // Atributos
        #region

        public string _IdeDocente;
        public int _Ide;
        public string _Password;
        public string _Name;
        public string _SurName;
        public string _SecondName;
        public string _Materia;
        public object _Grado1;
        public string _ResultMateria;
        public string _GradoALVM;
        public string _SeccionALVM;

        #endregion


        // Propiedades
        #region Propiedades
        public string IdeDocente
        {
            get { return this._IdeDocente; }
            set { SetValue(ref this._IdeDocente, value); }
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

        public string Materia
        {
            get { return this._Materia; }
            set { SetValue(ref this._Materia, value); }
        }

        public object Grado1
        {
            get { return this._Grado1; }
            set { SetValue(ref this._Grado1, value); }
        }

        public string ResultMateria
        {
            get { return this._ResultMateria; }
            set { SetValue(ref this._ResultMateria, value); }
        }

        // object
        public string ResultGrado
        {
            get { return this._GradoALVM; }
            set { SetValue(ref this._GradoALVM, value); }
        }

        public string ResultSeccion
        {
            get { return this._SeccionALVM; }
            set { SetValue(ref this._SeccionALVM, value); }
        }


        #endregion


        // comando del boton Añadir alumno
        public ICommand AñadirDocenteGUI => new Command(insertarDocente);
        



        // ingreso de datos del adminstrador
        public async void insertarDocente()
        {

            var Docentes = new Docente()
            {
                IdeDocente = IdeDocente,
                Ide = Ide,
                Password = Password,
                Name = Name,
                SurName = SurName,
                SecondName = SecondName,
                Materia = Materia,
            };

            var cursoDocentes = new Cursos()
            {
                Matematica = "",
            };

            var GradoDocentes = new Grado()
            {
                Seccion = ResultSeccion,
                
                Curso = cursoDocentes,
            };


            await DocenteFB.AgregarDatosDocente(Docentes, GradoDocentes);

            LimpiarEntry();


        }


        public void LimpiarEntry()
        {
            Ide = 0;
            IdeDocente = "";
            Password = "";
            Name = "";
            SurName = "";
            SecondName = "";
            ResultMateria = "";
            ResultGrado = "";
            ResultSeccion = "";
        }

    }
}
