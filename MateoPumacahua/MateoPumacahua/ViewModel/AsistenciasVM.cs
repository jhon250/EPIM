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
        DataBaseFB DataBase_FB = new DataBaseFB();
        //AlumnosDataFB Alumnos = new AlumnosDataFB();
        List<User_template> Asistencias;
        string data;
        #region Constructor
        public AsistenciasVM(List<User_template> User, string Data)
        {
            Asistencias = User;
            data = Data;
             LoadData(User,Data);
            
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
        public List<ListView_student_template> listViewSource;
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

        public List<ListView_student_template> ListViewSource
        {

            get { return this.listViewSource; }
            set { SetValue(ref this.listViewSource, value); }
        }

        //public string ColorPresente
        //{
        //    get { return this._colorPresente; }
        //    set { SetValue(ref this._colorPresente, value); }
        //}

        //public string ColorTarde
        //{
        //    get { return this._colorTarde; }
        //    set { SetValue(ref this._colorTarde, value); }
        //}

        //public string ColorFalta
        //{
        //    get { return this._colorFalta; }
        //    set { SetValue(ref this._colorFalta, value); }
        //}
        #endregion
        //-N1c0Jmr_ZH77iE8Rr8T
        #region Commands
        
        public ICommand Presente => new Command<ListView_student_template>((A) =>  SelectItems_Present(A));
        public ICommand Tarde => new Command<ListView_student_template>( (A) =>  SelectItems_Delay(A));
        public ICommand Falta => new Command<ListView_student_template>( (A) =>  SelectItems_Adsent(A));
        #endregion


        #region Methods
        public async void LoadData(List<User_template> User,string Table)
        {
            List<ListView_student_template> ListviewSource = new List<ListView_student_template>();
            if (ListviewSource.Count == 0)
            {
                //Console.WriteLine("lista"+ListviewSource.Count);
                foreach (var item in User)
                {
                    var Users_FB = await DataBase_FB.Query_Info_Tables(
                        item.Grado,
                        item.Seccion,
                        item.Materia);
                    string datetime = "7:35 AM";//DateTime.Now.ToString("hh:mm tt");
                    string date = DateTime.Now.Date.ToString("dd-MM-yyyy");

                    Fecha = date;
                    Seccion = item.Seccion;
                    Grado = item.Grado;
                    AlumnTotal = Users_FB.Count.ToString();

                    foreach (var item2 in Users_FB)
                    {
                        if (true)//(int.Parse(item2.StartTime.Substring(0, 1)) > int.Parse(datetime.Substring(0, 1)))
                            //&& (int.Parse(item2.StartTime.Substring(3, 4)) < int.Parse(datetime.Substring(3, 4))))
                        {
                            //Console.WriteLine(item2.KeyData);
                            var day = await DataBase_FB.Query_Day_Tables(
                            item.Grado,
                            item.Seccion,
                            item.Materia,
                            item2.KeyData,
                            date);
                            //Console.WriteLine(day.Count);
                            var Users = await DataBase_FB.Query_Users_Tables_Selected_Id("Students", item2.IdeStudent);
                            foreach (var item3 in Users)
                            {
                                //Console.WriteLine(item3.Name);
                                var data_list = new ListView_student_template()
                                {
                                    KeyUsers = item2.IdeStudent,
                                    KeyCourse = item2.KeyData,
                                    Keyday = day[0].Ides,
                                    Materia = item.Materia,
                                    Name = item3.Name,
                                    FirstName = item3.FirstName,
                                    SecondName = item3.SecondName,
                                    Grado = item.Grado,
                                    Seccion = item.Seccion,
                                    Present = day[0].Present,
                                    Delay = day[0].Delay,
                                    Absent = day[0].Absent,
                                };

                                ListviewSource.Add(data_list);
                            }

                        }
                        else { break; }
                    }
                }
            }
            
            Console.WriteLine(ListviewSource.Count);
            this.ListViewSource =  ListviewSource;
          
        }

        public async void SelectItems_Present(ListView_student_template A)
        {
                string date = DateTime.Now.Date.ToString("dd-MM-yyyy");
            if (A.Present == "#9CA29A")
            {
                var update = new Day_template()
                {
                    Present = "#1AF72A",
                    Delay = "#9CA29A",
                    Absent = "#9CA29A",
                };
                await DataBase_FB.Query_update_query_tables(
                    A.Grado,
                    A.Seccion,
                    A.Materia,
                    A.KeyCourse,
                    date,
                    A.Keyday,
                    update);
                LoadData(Asistencias, data);
            }
            else if (A.Present == "#1AF72A")
            {
                var update = new Day_template()
                {
                    Present = "#9CA29A",
                    Delay = A.Delay,
                    Absent = A.Absent,
                };
                await DataBase_FB.Query_update_query_tables(
                    A.Grado,
                    A.Seccion,
                    A.Materia,
                    A.KeyCourse,
                    date,
                    A.Keyday,
                    update);
                LoadData(Asistencias, data);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(
                 "E R R O R -- Asistencias",
                 "Asistencia no tomada",
                 "OK");
            }
            
        }

        public async void SelectItems_Delay(ListView_student_template A)
        {
            string date = DateTime.Now.Date.ToString("dd-MM-yyyy");
            if (A.Delay == "#9CA29A")
            {
                var update = new Day_template()
                {
                    Present = "#9CA29A",
                    Delay = "#F4F71A",
                    Absent = "#9CA29A",
                };
                await DataBase_FB.Query_update_query_tables(
                    A.Grado,
                    A.Seccion,
                    A.Materia,
                    A.KeyCourse,
                    date,
                    A.Keyday,
                    update);
                LoadData(Asistencias, data);
            }
            else if (A.Delay == "#F4F71A")
            {
                var update = new Day_template()
                {
                    Present = "#9CA29A",
                    Delay = "#9CA29A",
                    Absent = "#9CA29A",
                };
                await DataBase_FB.Query_update_query_tables(
                    A.Grado,
                    A.Seccion,
                    A.Materia,
                    A.KeyCourse,
                    date,
                    A.Keyday,
                    update);
                LoadData(Asistencias, data);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(
                 "E R R O R -- Asistencias",
                 "Asistencia no tomada",
                 "OK");
            }
        }

        public async void SelectItems_Adsent(ListView_student_template A)
        {
            string date = DateTime.Now.Date.ToString("dd-MM-yyyy");
            if (A.Absent == "#9CA29A")
            {
                var update = new Day_template()
                {
                    Present = "#9CA29A",
                    Delay = "#9CA29A",
                    Absent = "#FF0000",
                };
                await DataBase_FB.Query_update_query_tables(
                    A.Grado,
                    A.Seccion,
                    A.Materia,
                    A.KeyCourse,
                    date,
                    A.Keyday,
                    update);
                LoadData(Asistencias, data);
            }
            else if (A.Absent == "#FF0000")
            {
                var update = new Day_template()
                {
                    Present = "#9CA29A",
                    Delay = "#9CA29A",
                    Absent = "#9CA29A",
                };
                await DataBase_FB.Query_update_query_tables(
                    A.Grado,
                    A.Seccion,
                    A.Materia,
                    A.KeyCourse,
                    date,
                    A.Keyday,
                    update);
                LoadData(Asistencias, data);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(
                 "E R R O R -- Asistencias",
                 "Asistencia no tomada",
                 "OK");
            }
        }

       

        #endregion

    }
}
