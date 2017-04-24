using Newtonsoft.Json;
using ProyectoBarVCamarero.models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace ProyectoBarVCamarero.dal
{
    public class ProductoController
    {
        

        #region Builder
        public ProductoController()
        {

        }
        #endregion


        #region Functions


        /// <summary>
        ///  Metodo que recoge todas las productos
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Producto>> getProductos()
        {
            String url = "http://dleal.ciclo.iesnervion.es/Producto";
            Uri uri = new Uri(url);
        ObservableCollection<Producto> lista = new ObservableCollection<Producto>();
            HttpBaseProtocolFilter filtro = new HttpBaseProtocolFilter();
            filtro.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            filtro.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
            
            HttpClient mihttpClient = new HttpClient(filtro);
            string encoded = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("admin"));
            mihttpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);

            try
            {
                string respuesta = await mihttpClient.GetStringAsync(uri);
                mihttpClient.Dispose();
                lista = JsonConvert.DeserializeObject<ObservableCollection<Producto>>(respuesta);

                
            }
            catch (Exception)
            {

            }

            return lista;
        }



        /// <summary>
        ///  Metodo que edita un producto 
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> editProduct(Producto p)
        {
            String url = "http://dleal.ciclo.iesnervion.es/Producto/"+p.Id;
            Uri uri = new Uri(url);
            HttpResponseMessage res=null;

            HttpClient mihttpClient = new HttpClient();

          
         string encoded = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("admin"));



            mihttpClient.DefaultRequestHeaders.Add("Authorization", "Basic "+encoded);

            string jsonconvertido = JsonConvert.SerializeObject(p);
            IHttpContent contentPut = new HttpStringContent(jsonconvertido, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
            try
            {
               res= await mihttpClient.PutAsync(uri, contentPut);
                mihttpClient.Dispose();
            }
            catch (Exception)
            {

            }
            return res;
            
        }

        /// <summary>
        ///  Metodo que añade un producto 
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> addProducto(Producto p)
        {
            String url = "http://dleal.ciclo.iesnervion.es/Producto";
            Uri uri = new Uri(url);
            HttpResponseMessage res = null;

            HttpClient mihttpClient = new HttpClient();


            string encoded = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("admin"));
            mihttpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);

            string jsonconvertido = JsonConvert.SerializeObject(p);
            IHttpContent contentPut = new HttpStringContent(jsonconvertido, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
            try
            {
                res = await mihttpClient.PostAsync(uri, contentPut);
                mihttpClient.Dispose();
            }
            catch (Exception)
            {

            }
            return res;

        }

        #endregion
    }
}
