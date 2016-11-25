using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace _Binding2.Models
{
    public class clsListado
    {
       public ObservableCollection<clsPersona> list { get; set; }

        public clsListado()
        {
            list = new ObservableCollection<clsPersona>();
            list.Add(new clsPersona("Dani", "Leal" ,new DateTime(1995,10,10),"677356902","crack"));
            list.Add(new clsPersona("Dani", "Leal", new DateTime(1995, 10, 10), "677356902", "crack"));
            list.Add(new clsPersona("Gracias", "Leal", new DateTime(1995, 10, 10), "677356902", "crack"));
            list.Add(new clsPersona("Pepe", "Leal", new DateTime(1995, 10, 10), "677356902", "crack"));
            list.Add(new clsPersona("Rosi", "Leal", new DateTime(1995, 10, 10), "677356902", "crack"));
            list.Add(new clsPersona("JEJE", "Saludos", new DateTime(1995, 10, 10), "677356902", "crack"));


        }

       


        


    }
}