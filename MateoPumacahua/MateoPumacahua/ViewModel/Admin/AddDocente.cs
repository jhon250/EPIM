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
        DataBaseFB User_FB = new DataBaseFB();

        #region Constructor
        public AddDocente()
        {
            
        }
        #endregion

        // Atributos
        #region atributos

        public int _Ide;
        public string _Password;
        public string _Name;
        public string _SurName;
        public string _SecondName;
        public string _Correo;
        public string _Phone;
        public string _Materia;
        public string _ResultMateria;
        public string _GradoALVM;
        public string _SeccionALVM;
        public string GeneroALVM;

        #endregion


        // Propiedades
        #region Propiedades
        public string ResultGenero
        {
            get { return this.GeneroALVM; }
            set { SetValue(ref this.GeneroALVM, value); }
        }

        public string Phone
        {
            get { return this._Phone; }
            set { SetValue(ref this._Phone, value); }
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

        public string Correo
        {
            get { return this._Correo; }
            set { SetValue(ref this._Correo, value); }
        }

        public string Materia
        {
            get { return this._Materia; }
            set { SetValue(ref this._Materia, value); }
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
        public ICommand AñadirDocenteGUI => new Command(insertDocente);



        #region Metodos

        // ingreso de datos del adminstrador
        public async void insertDocente()
        {

            var i = new Teacher_template() { };
            var Teacher = new User_template()
            {
                Ide = Ide.ToString(),
                Password = Password,
                Name = Name,
                FirstName = SurName,
                SecondName = SecondName,
                Correo = Correo,
                Phone = Phone,
                Materia = ResultMateria,
                Genero = ResultGenero,
                Grado = ResultGrado,
                Seccion = ResultSeccion,
            };


            await User_FB.Create_Users_Tables(Teacher, "Teacher",i);

            LimpiarEntry();

        }


        public void LimpiarEntry()
        {
            Ide = 0;
            Password = "";
            Name = "";
            SurName = "";
            SecondName = "";
            Phone = "";
            ResultMateria = "";
            ResultGrado = "";
            ResultSeccion = "";
            ResultGenero = "";
        }
        #endregion

    }
}
