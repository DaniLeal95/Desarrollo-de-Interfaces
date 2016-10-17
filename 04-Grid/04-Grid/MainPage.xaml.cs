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

            Boolean valido=true;

            //Validacion Nombre
            if (!String.IsNullOrEmpty(txtNombre.Text))
            {

                lblErrorNombre.Text = "";
             
            }
            else
            {
                lblErrorNombre.Text = "El nombre no puede estar vacío";
                valido = false;
                
            }

            //Validacion Apellidos
            if (!String.IsNullOrEmpty(txtApellidos.Text))
            {
                lblErrorApellidos.Text = "";
                
            }
            else
            {
                lblErrorApellidos.Text = "El Apellido no puede estar vacío";
                valido = false;
            }
            //Validacion de la fecha
            if (!(Fecha.Date == null))
            {
                

                if (Fecha.Date < DateTime.Now)
                {
                    lblErrorFecha.Text = "";
                    
                }
                else
                {
                    lblErrorFecha.Text = "La fecha debe ser anterior a la actual.";
                    valido = false;
                }
            }
            else{
                lblErrorFecha.Text = "La fecha no puede estar Vacía";
                valido = false;
            }


            if (valido)
            {
                persona = new clsPersona(txtNombre.Text, txtApellidos.Text, Fecha.Date);
            }
            

            lblPersona.Text = persona.ToString();
            

        }
    }
}
