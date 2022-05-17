using MateoPumacahua.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MateoPumacahua.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertDocente : ContentPage
    {
        public InsertDocente()
        {
            InitializeComponent();
            BindingContext = new AddDocente();

            // anadiendo elementos a grado
            GradoPicker.Items.Add("Grado 1");
            GradoPicker.Items.Add("Grado 2");
            GradoPicker.Items.Add("Grado 3");
            GradoPicker.Items.Add("Grado 4");
            GradoPicker.Items.Add("Grado 5");

            // añadiendo elementos de seccion
            SeccionPicker.Items.Add("Seccion A");
            SeccionPicker.Items.Add("Seccion B");
            SeccionPicker.Items.Add("Seccion C");
            SeccionPicker.Items.Add("Seccion D");
            SeccionPicker.Items.Add("Seccion E");
            SeccionPicker.Items.Add("Seccion F");
            SeccionPicker.Items.Add("Seccion G");
            SeccionPicker.Items.Add("Seccion H");
            SeccionPicker.Items.Add("Seccion I");
            SeccionPicker.Items.Add("Seccion J");

            // añadir elementos de genero
            MateriaPicker.Items.Add("Matematicas");
            MateriaPicker.Items.Add("Comunicacion");
        }
    }
}