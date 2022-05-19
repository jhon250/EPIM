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
        AlumnosDataFB AlumnosFB = new AlumnosDataFB();
        DocenteDataFB DocenteFB = new DocenteDataFB();
        AdminDataFB AdminFB = new AdminDataFB();

        #region Constructor
        public MiPerfilVM(string IDE, string Data)
        {
            Display(IDE, Data);
        }
        #endregion

        #region atributos
        public int _Ide;
        public string _Name;
        public string _SurName;
        public string _SecondName;
        public string _Correo;
        public bool _Edita;
        public string _Color;

        #endregion

        #region Propiedades
        public int Ide
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

        public string Color
        {
            get { return this._Color; }
            set { SetValue(ref this._Color, value); }
        }
        #endregion

        #region Commandos
        public ICommand Editar => new Command(Edit);
        public ICommand Guardar => new Command(Save);
        #endregion

        #region Metodos
        public async void Display(string IDE,string Data)
        {
            if (Data == "Alumno")
            {
                var alumno = await AlumnosFB.IniciarSesionApp(IDE);
                #region AgregarData
                foreach (var item in alumno)
                {
                    Ide = item.Ide;
                    Name = item.Name;
                    SurName = item.SurName;
                    SecondName = item.SecondName;
                }
                Edita= true;
                Color = "Black";
                #endregion
            }

            else if (Data == "Docente")
            {
                var docente = await DocenteFB.IniciarSesionApp(IDE);
                #region AgregarData
                foreach (var item in docente)
                {
                    Ide = item.Ide;
                    Name = item.Name;
                    SurName = item.SurName;
                    SecondName = item.SecondName;
                }
                Edita = true;
                Color = "Black";
                #endregion
            }
            else
            {
                var admin = await AdminFB.IniciarSesionApp_Admin(IDE);
                #region AgregarData
                foreach (var item in admin)
                {
                    Ide = item.Ide;
                    Name = item.Name;
                    SurName = item.SurName;
                    SecondName = item.SecondName;
                }
                Edita = true;
                Color = "Black";
                #endregion
            }
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
