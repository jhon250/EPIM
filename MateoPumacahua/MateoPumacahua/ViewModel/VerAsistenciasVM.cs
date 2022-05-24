using MateoPumacahua.FireBase;
using MateoPumacahua.Model;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MateoPumacahua.ViewModel
{
    public class VerAsistenciasVM:BaseViewModel
    {

        DataBaseFB DataBase_FB = new DataBaseFB();
        //AlumnosDataFB Alumnos = new AlumnosDataFB();

        #region Constructor
        public VerAsistenciasVM(List<User_template> User, string Data)
        {

            _ = LoadData(User, Data);

        }
        #endregion

        #region Atributos
        public string _Fecha;
        public string _Seccion;
        public string _Grado;
        public string _AlumnTotal;
        public bool isRefreshing = false;
        public object listViewSource;

        #endregion

        #region Propiedades
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

        public object ListViewSource
        {

            get { return this.listViewSource; }
            set { SetValue(ref this.listViewSource, value); }
        }
        #endregion
        //-N1c0Jmr_ZH77iE8Rr8T

        #region Commands

        #endregion


        #region Methods
        public async Task LoadData(List<User_template> User, string Table)
        {
            List<ListView_student_template> ListviewSource = new List<ListView_student_template>();
            foreach (var item in User)
            {
            Console.WriteLine("cargar data");Console.WriteLine(item.Grado);
                var course = DataBase_FB.Course_List(item.Grado);
                    Console.WriteLine(course.Count);

                for (int i = 1; i <= course.Count; i++)
                {
                    var Users_FB = await DataBase_FB.Query_Info_Tables(
                        item.Grado,
                        item.Seccion,
                        course[i]);

                    string datetime = DateTime.Now.ToString("hh:mm tt");
                    string date = DateTime.Now.Date.ToString("dd-MM-yyyy");

                    Console.WriteLine(datetime,date);
                    Fecha = date;
                    Seccion = item.Seccion;
                    Grado = item.Grado;
                    AlumnTotal = course.Count.ToString();

                    // recorriendo cada uno de los alumnos
                    foreach (var item2 in Users_FB)
                    {
                        if (item2.IdeStudent==item.Ide)
                        {
                            // consultando dia de asistencia del alumno
                            var day = await DataBase_FB.Query_Day_Tables(
                            item.Grado,
                            item.Seccion,
                            course[i],
                            item2.KeyData,
                            date);

                            // consultando si existe lo datos del alumno
                            //var Users = await DataBase_FB.Query_Users_Tables_Selected_Id("Students", item2.IdeStudent);

                            // recorriendo los daros existentes
                            foreach (var item3 in day)
                            {
                                // agregando datos utilizando el modelo
                                var data_list = new ListView_student_template()
                                {
                                    KeyUsers = item2.KeyData,
                                    Materia = course[i],
                                    Grado = item.Grado,
                                    Seccion = item.Seccion,
                                    Present = item3.Present,
                                    Delay = item3.Delay,
                                    Absent = item3.Absent,
                                };

                                // Agrenado los datos a la lista
                                ListviewSource.Add(data_list);
                                break;
                            }
                        }
                        else
                        {
                            //await App.Current.MainPage.DisplayAlert(
                            //    "H O R A -- V E N C I D A ",
                            //    "no hay datos que mostrar, por se paso la hora",
                            //    "OK");
                            //break;
                        }

                    }
                    
                }

            }

            //mostrar la lista de datos
            ListViewSource = ListviewSource;

        }

        #endregion

    }
}
