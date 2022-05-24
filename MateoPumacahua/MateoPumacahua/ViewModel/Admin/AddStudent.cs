using CommunityToolkit.Mvvm.Input;
using MateoPumacahua.FireBase;
using MateoPumacahua.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MateoPumacahua.ViewModel.Admin
{
    public class AddStudent : BaseViewModel
    {
        // instaciamos el crud alumnos
        DataBaseFB User_FB = new DataBaseFB();

        #region Constructor
        public AddStudent()
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

        #region Comandos
        // comando del boton Añadir alumno
        public ICommand AñadirDocenteGUI => new Command(InsertDocente);
        public ICommand Data_AddGUI => new Command(Data_Add);

        #endregion

        #region Metodos

        // ingreso de datos del adminstrador
        public async void InsertDocente()
        {

            var i = new Teacher_template() { };
            var Student = new User_template()
            {
                Ide = Ide.ToString(),
                Password = Password,
                Name = Name,
                FirstName = SurName,
                SecondName = SecondName,
                Correo = Correo,
                Phone = Phone,
                Genero = ResultGenero,
                Grado = ResultGrado,
                Seccion = ResultSeccion,
            };

            await User_FB.Create_Users_Tables(Student, "Students", i);

            var cursos =  User_FB.Course_List(ResultGrado);
            var startTime = User_FB.Start_Time_List();
            var endTime = User_FB.End_Time_List();
            for (int j = 1; j <= cursos.Count; j++)
            {
                var Alumn = new Info_Users_Template()
                {
                    IdeStudent = Ide.ToString(),
                    IdeTeacher = "",
                    StartTime = startTime[j],
                    EndTime = endTime[j],
                };
                // creando data_teplate
                User_FB.Create_Data_template(
                    ResultGrado,
                    ResultSeccion,
                    cursos[j],
                    Alumn);
                await App.Current.MainPage.DisplayAlert("Datos", "Datos guardados", "OK");
                // consultando data_teplate creada
                var Course_data = await User_FB.Query_Info_Tables_Ide(
                    ResultGrado,
                    ResultSeccion,
                    cursos[j],
                    Ide.ToString());

                // verificando que solo contenga

                foreach (var item in Course_data)
                {
                    if (Course_data.Count <=10)
                    {
                        for (int e = 1; e < 32; e++)
                        {
                            var fecha = new Day_template()
                            {
                                Present = "#9CA29A",
                                Delay = "#9CA29A",
                                Absent = "#9CA29A",
                            };string date = e + "-05-2022";
                            Console.WriteLine(date);
                            User_FB.Create_Day_Tables(
                                ResultGrado,
                                ResultSeccion,
                                cursos[j],
                                item.KeyData,
                                date,
                                fecha);
                        }
                    }else
                    {
                        await App.Current.MainPage.DisplayAlert("error","dias no guardados","OK");
                        User_FB.Delete_Info_Tables_Ide(
                            ResultGrado,
                            ResultSeccion,
                            cursos[j],
                            item.KeyData);
                        break;
                    }
                }
                
            }

            LimpiarEntry();

        }

        public async void Data_Add()
        {

        }
        public void LimpiarEntry()
        {
            Ide = 0;
            Password = "";
            Name = "";
            SurName = "";
            SecondName = "";
            Phone = "";
            ResultGenero = "";
            ResultGrado = "";
            ResultSeccion = "";
        }
        #endregion

    }
}
