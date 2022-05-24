using MateoPumacahua.FireBase;
using MateoPumacahua.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MateoPumacahua.ViewModel
{
    public class MiPerfilVM : BaseViewModel
    {
        

        #region Constructor
        public MiPerfilVM(List<User_template> User, string Data)
        {
            Display(User, Data);
        }
        #endregion

        #region atributos
        public string _Ide;
        public string _Name;
        public string _SurName;
        public string _SecondName;
        public string _Correo;
        public string _Phone;
        public string _Materia;
        public string _Grado;
        public string _Seccion;
        public bool _Edita;
        public bool _Visible;
        public string _Color;

        #endregion

        #region Propiedades
        public string Ide
        {
            get { return this._Ide; }
            set { SetValue(ref this._Ide, value); }
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
        public string Materia
        {
            get { return this._Materia; }
            set { SetValue(ref this._Materia, value); }
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

        public bool Edita
        {
            get { return this._Edita; }
            set { SetValue(ref this._Edita, value); }
        }
        public bool Visible
        {
            get { return this._Visible; }
            set { SetValue(ref this._Visible, value); }
        }

        public string Color
        {
            get { return this._Color; }
            set { SetValue(ref this._Color, value); }
        }

        public string Phone
        {
            get { return this._Phone; }
            set { SetValue(ref this._Phone, value); }
        }

        public string Grado
        {
            get { return this._Grado; }
            set { SetValue(ref this._Grado, value); }
        }

        public string Seccion
        {
            get { return this._Seccion; }
            set { SetValue(ref this._Seccion, value); }
        }
        #endregion

        #region Commandos
        public ICommand Editar => new Command(Edit);
        public ICommand Guardar => new Command(Save);
        #endregion

        #region Metodos
        public void Display(List<User_template> User,string Data)
        {
            if (Data != "Teacher") { Visible = false; } else { Visible = true; }
            
            foreach (var item in User)
            {
                //KeyUser = item.KeyUser;
                Ide = item.Ide;
                Name = item.Name;
                SurName = item.FirstName;
                SecondName = item.SecondName;
                Correo = item.Correo;
                Phone = item.Phone;
                Grado = item.Grado;
                Seccion = item.Seccion;
                Materia = item.Materia;
            }
            Edita = true;
            Color = "Black";
            //if (Data == "Alumno")
            //{
            //    var alumno = await AlumnosFB.IniciarSesionApp(IDE);
            //    #region AgregarData
            //    foreach (var item in User)
            //    {
            //        Ide = item.Ide;
            //        Name = item.Name;
            //        SurName = item.SurName;
            //        SecondName = item.SecondName;
            //    }
            //    Edita= true;
            //    Color = "Black";
            //    #endregion
            //}

            //else if (Data == "Docente")
            //{
            //    var docente = await DocenteFB.IniciarSesionApp(IDE);
            //    #region AgregarData
            //    foreach (var item in docente)
            //    {
            //        Ide = item.Ide;
            //        Name = item.Name;
            //        SurName = item.SurName;
            //        SecondName = item.SecondName;
            //    }
            //    Edita = true;
            //    Color = "Black";
            //    #endregion
            //}
            //else
            //{
            //    var admin = await AdminFB.IniciarSesionApp_Admin(IDE);
            //    #region AgregarData
            //    foreach (var item in admin)
            //    {
            //        Ide = item.Ide;
            //        Name = item.Name;
            //        SurName = item.SurName;
            //        SecondName = item.SecondName;
            //    }
            //    Edita = true;
            //    Color = "Black";
            //    #endregion
            //}
        }
        public void Edit()
        {
            Edita = false;
            Color = "Red";
        }
        public void Save()
        {
            Edita = true;
            Color = "Black";
        }
        #endregion

    }
}
