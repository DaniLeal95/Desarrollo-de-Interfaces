using _Binding2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Binding2.DAL
{
    public class ManejadoraPersona
    {
        string stringurl = "http://webapirestdanileal.azurewebsites.net/api/personas/";

        public async Task<ObservableCollection<clsPersona>> DeletePersona(int id)
        {
            ObservableCollection<clsPersona> lista = new ObservableCollection<clsPersona>();
            //HttpBaseProtocolFilter filtro = new HttpBaseProtocolFilter();
            //filtro.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            //filtro.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
            HttpClient mihttpClient = new HttpClient();

            try
            {

                stringurl = stringurl + id;
                Uri url = new Uri(stringurl);
                lista = JsonConvert.DeserializeObject<ObservableCollection<clsPersona>>(respuesta);
            }
            catch (Exception)
            {

            }

            return lista;
        }
    }
}
