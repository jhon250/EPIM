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
        public AsistenciasVM(string grado, string seccion)
        {
            _ = LoadData(grado,seccion);
            
        }
        #endregion

        #region Atributos
        public string _Name;
        public string _SurName;
        public string _SecondName;
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
        public async Task LoadData(string grado, string seccion)
        {

            //var list = await Alumnos.MostrarAlumnos_Asistencia(grado, seccion);
            //ListViewSource = list;
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
