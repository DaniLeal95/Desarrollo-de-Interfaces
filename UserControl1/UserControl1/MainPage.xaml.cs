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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UserControl1
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static int columna=0;
        private static int fila=0;

        public MainPage()
        {
            this.InitializeComponent();
        }

        public void insertarFicha(String nombre,String apellidos,String uri)
        {
            //Creamos el UserControl
            BitmapImage image = new BitmapImage(new Uri(uri, UriKind.Absolute));

            UserControls.fichaAlumno newAlumno = new UserControls.fichaAlumno();
            newAlumno.Foto = image;
            newAlumno.StudentName = nombre;
            newAlumno.StudentFirstName = apellidos;

            newAlumno.HorizontalContentAlignment = HorizontalAlignment.Center;
         

            //Añadimos una fila
            RowDefinition row = new RowDefinition();
            row.Height = Windows.UI.Xaml.GridLength.Auto;
            Grid grid = gridPrincipal;
            RowDefinitionCollection coleccion = gridPrincipal.RowDefinitions;
            coleccion.Add(row);

            grid.Children.Add(newAlumno);


            
            //grid.Children.Add(boton);
            

            //Image imagen = new Image();





            //grid.Children.Add(column);
            columna += 1;
            fila += 1;



        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.insertarFicha("Dani", "leal", "https://media.licdn.com/mpr/mpr/shrinknp_200_200/AAEAAQAAAAAAAAftAAAAJDI3ZGNjMGU1LWY5NTEtNGQwOC04MGZiLWE3MmEyOGFkMzA1Yg.jpg");
        }
    }
}
