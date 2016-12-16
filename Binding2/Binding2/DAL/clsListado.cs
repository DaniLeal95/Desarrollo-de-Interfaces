﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Newtonsoft.Json;
namespace _Binding2.Models
{
    public class clsListado
    {
        private ObservableCollection<clsPersona> _list;
        private Uri uri = new Uri( "http://webapirestdanileal.azurewebsites.net/api/personas");

        public clsListado()
        {
            //list = new ObservableCollection<clsPersona>();
            /*list.Add(new clsPersona("Dani", "Leal" ,new DateTime(1995,10,10),"677356902","crack"));
            list.Add(new clsPersona("Dani", "Leal", new DateTime(1995, 10, 10), "677356902", "crack"));
            list.Add(new clsPersona("Gracias", "Leal", new DateTime(1995, 10, 10), "677356902", "crack"));
            list.Add(new clsPersona("Pepe", "Leal", new DateTime(1995, 10, 10), "677356902", "crack"));
            list.Add(new clsPersona("Rosi", "Leal", new DateTime(1995, 10, 10), "677356902", "crack"));
            list.Add(new clsPersona("JEJE", "Saludos", new DateTime(1995, 10, 10), "677356902", "crack"));*/


        }





        public async Task<ObservableCollection<clsPersona>> getPersonas()
        {
            ObservableCollection<clsPersona> lista = new ObservableCollection<clsPersona>();
            HttpBaseProtocolFilter filtro = new HttpBaseProtocolFilter();
            filtro.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            filtro.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
            HttpClient mihttpClient = new HttpClient(filtro);

            try
            {
                string respuesta = await mihttpClient.GetStringAsync(uri);
                mihttpClient.Dispose();
                lista=JsonConvert.DeserializeObject<ObservableCollection<clsPersona>>(respuesta);
            }
            catch (Exception)
            {
                
            }

            return lista;
        }
    }
}