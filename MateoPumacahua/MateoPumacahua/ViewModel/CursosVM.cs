using MateoPumacahua.FireBase;
using MateoPumacahua.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MateoPumacahua.ViewModel
{
    public class CursosVM:BaseViewModel
    {
        DataBaseFB DataBase_FB = new DataBaseFB();

        #region Constructor
        public CursosVM(List<User_template> User,string Data)
        {
            LoadData(User, Data);
        }
        #endregion

        #region Atributos
        public bool isRefreshing;
        public List<ListView_student_template> _ListViewSource;

        #endregion

        #region Propiedades
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        public List<ListView_student_template> ListViewSource
        {

            get { return this._ListViewSource; }
            set { SetValue(ref this._ListViewSource, value); }
        }
        #endregion


        #region Command

        #endregion


        #region Mothodo
        public void LoadData(List<User_template> User,string Data)
        {
            List<ListView_student_template> ListviewSource = new List<ListView_student_template>();

            foreach (var item in User)
            {
                var course =  DataBase_FB.Course_List(item.Grado);
                for (int i = 1; i <= course.Count; i++)
                {
                    var list = new ListView_student_template()
                    {
                        Name = course[i],
                        Grado = item.Grado,
                        Seccion = item.Seccion,
                    };
                    ListviewSource.Add(list);
                }
                
            }
            ListViewSource = ListviewSource;
        }
        #endregion
    }
}
