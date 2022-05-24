using Firebase.Database;
using Firebase.Database.Query;
using MateoPumacahua.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoPumacahua.FireBase
{
    

    public class DataBaseFB
    {
        private FirebaseClient Data_template_FB;
        //private FirebaseClient Grado2;
        //private FirebaseClient Grado3;
        //private FirebaseClient Grado4;
        //private FirebaseClient Grado5;
        
        public DataBaseFB()
        {
            Data_template_FB = new FirebaseClient("https://mateopumacahua-867d0-default-rtdb.firebaseio.com/");
            
        }


        #region Creation of tables and Users Query
        public async Task Create_Users_Tables(User_template Users,string Table,Teacher_template Teacher)
        {
            await Data_template_FB.Child(Table).PostAsync(new User_template()
            {
                Ide = Users.Ide,
                Password = Users.Password,
                Name = Users.Name,
                FirstName = Users.FirstName,
                SecondName = Users.SecondName,
                Correo = Users.Correo,
                Genero = Users.Genero,
                Phone = Users.Phone,
                Grado = Users.Grado,
                Seccion = Users.Seccion,
                Materia = Users.Materia,
                Teacher = Teacher,
            });
        }

        // consultar tablas de datos 
        public async Task<List<User_template>> Query_Users_Tables_Login(
            string IdeGUI,
            string PasswordGUI,
            string Table)
        {
            var Users = await Query_Users_Tables(Table);
            return Users.Where(User => User.Ide == IdeGUI && User.Password == PasswordGUI).ToList();
        }

        public async Task<List<User_template>> Query_Users_Tables(string Table)
        {
            return (await Data_template_FB.Child(Table)
                .OnceAsync<User_template>())
                .Select(item => new User_template
                {
                    KeyUser = item.Key,
                    Ide = item.Object.Ide,
                    Password = item.Object.Password,
                    Name = item.Object.Name,
                    FirstName = item.Object.FirstName,
                    SecondName = item.Object.SecondName,
                    Correo = item.Object.Correo,
                    Genero = item.Object.Genero,
                    Phone = item.Object.Phone,
                    Grado = item.Object.Grado,
                    Seccion = item.Object.Seccion,
                    Materia = item.Object.Materia,
                }).ToList();
        }

        public async Task<List<User_template>> Query_Users_Tables_Selected_Id(
            string Table,
            string IdeUser)
        {
            var Users = await Query_Users_Tables(Table);
            return Users.Where(User => User.Ide == IdeUser).ToList();
        }

        #endregion



        #region Creation of tables and Data Query

        public async void Create_Data_template(
            string Table,
            string SubTable,
            string SubbTable,
            Info_Users_Template Cours_Alumn_Template)
        {
            // (grado - Seccion - Curso)
            await Data_template_FB
                .Child(Table)
                .Child(SubTable)
                .Child(SubbTable)
                .PostAsync(new Info_Users_Template()
                {
                    IdeStudent = Cours_Alumn_Template.IdeStudent,
                    IdeTeacher = Cours_Alumn_Template.IdeTeacher,
                    StartTime = Cours_Alumn_Template.StartTime,
                    EndTime = Cours_Alumn_Template.EndTime,
                });
        }

        public async void Create_Day_Tables(
            string Table, 
            string SubTable, 
            string SubbTable, 
            string Ide,
            string Day,
            Day_template Days_template)
        {
            // (grado - Seccion - Curso - Ide)
            await Data_template_FB
                .Child(Table)
                .Child(SubTable)
                .Child(SubbTable)
                .Child(Ide)
                .Child(Day)
                .PostAsync(new Day_template()
                {
                    Present = Days_template.Present,
                    Delay = Days_template.Delay,
                    Absent = Days_template.Absent,
                });
        }

        //Query
        public async Task<List<Info_Users_Template>> Query_Info_Tables(
            string Table,
            string SubTable,
            string SubbTable )
        {
            // (grado - Seccion - Curso)
            return (await Data_template_FB
                .Child(Table)
                .Child(SubTable)
                .Child(SubbTable)
                .OnceAsync<Info_Users_Template>())
                .Select(item => new Info_Users_Template()
                {
                    KeyData = item.Key,
                    IdeStudent = item.Object.IdeStudent,
                    IdeTeacher = item.Object.IdeTeacher,
                    StartTime = item.Object.StartTime,
                    EndTime = item.Object.EndTime,
                }).ToList();
        }

        public async Task<List<Info_Users_Template>> Query_Info_Tables_Ide(
            string Table,
            string SubTable,
            string SubbTable,
            string IDE)
        {
            // (grado - Seccion - Curso)
            var Info_data_all = await Query_Info_Tables(
                Table,
                SubTable,
                SubbTable);
            return (Info_data_all.Where(user => user.IdeStudent == IDE).ToList());
                
        }

        public async Task<List<Day_template>> Query_Day_Tables(
            string Table,
            string SubTable,
            string SubbTable,
            string Ide,
            string Day)
        {
            // (grado - Seccion - Curso - Ide)
            return (await Data_template_FB
                .Child(Table)
                .Child(SubTable)
                .Child(SubbTable)
                .Child(Ide)
                .Child(Day)
                .OnceAsync<Day_template>())
                .Select(Item => new Day_template()
                {
                    Ides = Item.Key,
                    Present = Item.Object.Present,
                    Delay = Item.Object.Delay,
                    Absent = Item.Object.Absent,
                }).ToList();
        }

        public async Task Query_update_query_tables(
            string Table,
            string SubTable,
            string SubbTable,
            string Ide,
            string Day,
            string daykey,
            Day_template update)
        {
            await Data_template_FB
                .Child(Table)
                .Child(SubTable)
                .Child(SubbTable)
                .Child(Ide)
                .Child(Day)
                .Child(daykey)
                .PutAsync(update);
        }

        // Delete 
        public async void Delete_Info_Tables_Ide(
            string Table,
            string SubTable,
            string SubbTable,
            string IDE)
        {
            // (grado - Seccion - Curso)
            await Data_template_FB
                .Child(Table)
                .Child(SubTable)
                .Child(SubbTable)
                .Child(IDE)
                .DeleteAsync();

        }
        #endregion

        #region Course List
        public Dictionary<int,string> Course_List(string Grado)
        {
            Dictionary<int,string> Courses = new Dictionary<int, string>();
            //List<string> Courses = new List<string>();
            if (Grado == "Grado 1" || Grado == "Grado 2")
            {

                Courses.Clear();
                Courses.Add(1, "Matematicas");
                Courses.Add(2, "Comunicacion");
                //Courses.Add( "Matematicas");
                //Courses.Add( "Comunicacion");
                //Courses.Add( "Geografia");
                //Courses.Add( "History");
                return Courses;
            }
            //else if (Grado == "Grado3")
            //{
            //    Courses.Clear();
            //    Courses.Add(1,"Matematicas");
            //    Courses.Add(2, "Comunicacion");
            //    Courses.Add(3, "Geografia");
            //    Courses.Add(4, "History");
            //    Courses.Add(5, "Geometria");
            //    return Courses;
            //}
            //else if (Grado == "Grado 4" || Grado == "Grado 5")
            //{
            //    Courses.Clear();
            //    Courses.Add(1, "Matematicas");
            //    Courses.Add(2, "Comunicacion");
            //    Courses.Add(3, "Geografia");
            //    Courses.Add(4, "History");
            //    Courses.Add(5, "Geometria");
            //    Courses.Add(6, "Trigonometria");
            //    return Courses;
            //}
            else { Courses.Clear(); return Courses; }
            
        }

        public Dictionary<int,string> Start_Time_List()
        {
            Dictionary<int,string> dict = new Dictionary<int,string>();
            dict.Clear();
            dict.Add(1, "7:30 AM");
            dict.Add(2, "9:00 AM");
            dict.Add(3, "10:50 AM");
            dict.Add(4, "2:00 PM");
            dict.Add(5, "3:50 PM");
            dict.Add(6, "5:00 PM");
            return dict;
        }
        public Dictionary<int, string> End_Time_List()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Clear();
            dict.Add(1, "8:59 AM");
            dict.Add(2, "10:30 AM");
            dict.Add(3, "12:30 AM");
            dict.Add(4, "3:30 PM");
            dict.Add(5, "4:59 PM");
            dict.Add(6, "6:00 PM");

            return dict;
        }
        #endregion


    }

    //public class SubData
    //{
    //    FirebaseClient Subdata_template_FB;

    //    public SubData(string SubTable)
    //    {
    //        Subdata_template_FB = new FirebaseClient("https://mateopumacahua-867d0-default-rtdb.firebaseio.com/"+SubTable+"/");
    //    }

    //}
}
