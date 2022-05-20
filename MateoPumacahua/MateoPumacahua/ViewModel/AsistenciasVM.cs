using CommunityToolkit.Mvvm.Input;
using MateoPumacahua.FireBase;
using MateoPumacahua.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MateoPumacahua.ViewModel
{
    public class AsistenciasVM : BaseViewModel
    {

        AlumnosDataFB Alumnos = new AlumnosDataFB();

        #region Constructor
        public AsistenciasVM(string Ide, string Data)
        {
            string datetime = DateTime.Now.ToString("hh:mmtt");
            _ = LoadData(Ide,datetime);
            
        }
        #endregion

        #region Atributos
        public string _Name;
        public string _SurName;
        public string _SecondName;
        public string _Fecha;
        public string _Seccion;
        public string _Grado;
        public string _AlumnTotal;
        public bool isRefreshing = false;
        public List<Alumno> listViewSource;
        public string _colorPresente;
        public string _colorTarde;
        public string _colorFalta;
        #endregion

        #region Propiedades
        //public string Name
        //{
        //    get { return this._Name; }
        //    set { SetValue(ref this._Name, value); }
        //}

        //public string SurName
        //{
        //    get { return this._SurName; }
        //    set { SetValue(ref this._SurName, value); }
        //}

        //public string SecondName
        //{
        //    get { return this._SecondName; }
        //    set { SetValue(ref this._SecondName, value); }
        //}

        public string Fecha
        {
            get { return this._Fecha; }
            set { SetValue(ref this._Fecha, value); }
        }

        public string Seccion
        {
            get { return this._Seccion; }
            set { SetValue(ref this._Seccion, value); }
        }

        public string Grado
        {
            get { return this._Grado; }
            set { SetValue(ref this._Grado, value); }
        }

        public string AlumnTotal
        {
            get { return this._AlumnTotal; }
            set { SetValue(ref this._AlumnTotal, value); }
        }
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public List<Alumno> ListViewSource
        {

            get { return this.listViewSource; }
            set { SetValue(ref this.listViewSource, value); }
        }

        public string ColorPresente
        {
            get { return this._colorPresente; }
            set { SetValue(ref this._colorPresente, value); }
        }

        public string ColorTarde
        {
            get { return this._colorTarde; }
            set { SetValue(ref this._colorTarde, value); }
        }

        public string ColorFalta
        {
            get { return this._colorFalta; }
            set { SetValue(ref this._colorFalta, value); }
        }
        #endregion
        //-N1c0Jmr_ZH77iE8Rr8T
        #region Commands
        //public void SelectedItem(object sender, SelectedItemChangedEventArgs e)
        //{
        //    Console.WriteLine(e.SelectedItem);
        //}
        //public ICommand Presente
        //{
        //    get
        //    {
        //        return new Command((e) =>
        //        {
        //            var item = e as ICommand;
        //        });
        //    }
        //}

        //public ICommand SelectedItem => new Command(selectItem);
        public ICommand Presente => new Command<Alumno>(async(A) => await SelectItems_Present(A));
        //public ICommand Tarde => new Command<Alumno>(async (A) => await SelectItems(A));
        //public ICommand Falta => new Command<Alumno>(async (A) => await SelectItems(A));
        #endregion


        #region Methods
        public async Task LoadData(string IDE,string Hora_Inicio)
        {
            List<string> listView = new List<string>();
            var list = await Alumnos.Data_ListWiew(IDE, Hora_Inicio);
            foreach (Alumno item in list)
            {
                Fecha = Hora_Inicio;
                Seccion = item.Grado.Seccion;
                Grado = item.Grado.Grados;
                break;
            }
            AlumnTotal = list.Count.ToString();
            ListViewSource = await Alumnos.Data_ListWiew(IDE , Hora_Inicio);
            //ColorPresente = "#8D8D88";
        }

        public async Task SelectItems_Present(Alumno A)
        {
            ColorPresente = "Red";
             await App.Current.MainPage.DisplayAlert(
                      "Selected item", A.IdeAlumno
                       , "OK");
        }

        public  void Present()
        {
            
            //var data = _SelectedItem.Name;
            //Alumno allumno = _SelectedItem;
            //try
            //{

            //    await App.Current.MainPage.DisplayAlert(
            //          "",SelectedItem.GetType().Name
            //           , "OK"); ;
            //}catch (Exception)
            //{
            //    await App.Current.MainPage.DisplayAlert(
            //          "error", "vacio"
            //           ,
            //          "OK");
            //}
        }
        #endregion

    }
}
