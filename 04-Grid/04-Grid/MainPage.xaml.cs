using _04_Grid.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _04_Grid
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private clsPersona persona;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {

            persona=new clsPersona();

            //Validacion Nombre
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                lblErrorNombre.Text="El nombre no puede estar vacío";
            }
            else
            {
                lblErrorNombre.Text = "";
                persona.nombre = txtNombre.Text;
            }

            //Validacion Apellidos
            if (String.IsNullOrEmpty(txtApellidos.Text))
            {
                lblErrorApellidos.Text = "El Apellido no puede estar vacío";
            }
            else
            {
                lblErrorApellidos.Text = "";
                persona.apellido = txtApellidos.Text;
            }
            //Validacion de la fecha
            if (Fecha.Date == null)
            {
                lblErrorFecha.Text = "La fecha no puede estar Vacía";
            }
            else if(Fecha.Date > DateTime.Now)
            {
                lblErrorFecha.Text = "La fecha debe ser anterior a la actual.";
            }
            else
            {
                lblErrorFecha.Text = "";
                persona.fechaNacimiento = Fecha.Date;

            }

            lblPersona.Text = persona.ToString();
            

        }
    }
}
