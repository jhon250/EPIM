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
        //DataBase datas = new DataBase();
        AdminDataFB AdminFB = new AdminDataFB();
        DocenteDataFB DocenteFB = new DocenteDataFB();

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

        public ICommand ActualizarCursosGUI
        {
            get
            {
                // llamamos al metodo Inicio Sesion cuando
                // presione el boton
                return new RelayCommand(insertarCursos);
            }
        }

        public ICommand ActualizardiasGUI
        {
            get
            {
                // llamamos al metodo Inicio Sesion cuando
                // presione el boton
                return new RelayCommand(insertarCursos);
            }
        }

        // ingreso de datos del adminstrador
        public async void insertarAlumno()
        {
            
            var GradoAlumno = new Grado()
            {
                Grados = ResultGrado,
                Seccion = ResultSeccion,
                
                
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

            //LimpiarEntry();


        }
        public async void insertarCursos()
        {

            #region horas 

            List<string> hora = new List<string>();
            hora.Add("07:30 AM");
            hora.Add("09:00 AM");
            hora.Add("10:20 AM");
            hora.Add("12:00 AM");
            hora.Add("01:59 PM");
            hora.Add("03:00 PM");
            hora.Add("05:20 PM");

            List<string> hora_fin = new List<string>();
            hora_fin.Add("08:59 AM");
            hora_fin.Add("09:59 AM");
            hora_fin.Add("11:40 AM");
            hora_fin.Add("01:00 PM");
            hora_fin.Add("02:59 PM");
            hora_fin.Add("04:59 PM");
            hora_fin.Add("06:30 PM");

            #endregion

            var profes = await DocenteFB.Grado(ResultGrado);
            var Alumnos = await AlumnosFB.Iniciar(ResultGrado);

            int op = 0;int po = 0;
            foreach (var profe in profes)//3secciones
            {
                //Console.WriteLine("profe - "+profe.Name);
                foreach (var alum in Alumnos)//10
                {
                    DataBase datas = new DataBase(alum.IdeAlumno);
                    //int op = 0;
                    //Console.WriteLine("Alumno - "+alum.Name);break;
                    if (op==7 && po==7 ) { op = 0;po = 0; }
                    
                    var curs = new Course()
                    {

                        Curso = profe.Materia,
                        Hora_inicio = hora[op++],
                        Hora_fin = hora_fin[po++],
                        IdeDocenteC = profe.IdeDocente,
                    };
                    datas.Fun(curs);
                    var Curso = await datas.Course_data();
                    foreach (var cur in Curso)
                    {
                        int t=1;
                        for (int i = 0; i < 32; i++)
                        {
                            DIA dias = new DIA(alum.IdeAlumno, cur.IdeCurso);
                            var dia=new Day()
                            {
                                Mes = "Mayo",
                                Fecha = t+++"/05/2022",
                                Presente = "#8D8D88",
                                Tarde = "#8D8D88",
                                Falta = "#8D8D88",
                            };
                            dias.Dia(dia);
                        }
                    }
                }
            }
            //var dia = new Day() { };
            //var curso = new Course()
            //{
            //    Curso = "",
            //    IdeDocenteC = "",
            //    Hora_inicio = "",
            //    Hora_fin = "",
            //    Meses_dia = dia,
            //};




            LimpiarEntry();
            hora.Clear();
            hora_fin.Clear();

        }

        private async void InsertarDias(string id)
        {
            var dias = new Day()
            {

            };
        }


        public void LimpiarEntry()
        {
            Ide = 0;
            Password = "";
            Name = "";
            SurName = "";
            SecondName = "";
            ResultGrado = "";
            ResultSeccion = "";
            ResultGenero = "";
        }

    }
}
