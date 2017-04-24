using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;
using ProyectoBarVCamarero.dal;
using ProyectoBarVCamarero.models;
using System.Collections.ObjectModel;
using Windows.Web.Http;

namespace ProyectoBarVCamareroTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task getProductos()
        {
            ProductoController pc = new ProductoController();
            ObservableCollection<Producto> lista = await pc.getProductos();
            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public async Task editProduct()
        {
            ProductoController pc = new ProductoController();
            Producto p = new Producto(2, "Agua Mineral", 0.8, 1);

            HttpResponseMessage res = await pc.editProduct(p);
            Assert.IsTrue(res.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task postProduct()
        {
            ProductoController pc = new ProductoController();
            Producto p = new Producto(0, "TestProduct", 0.1, 4);

            HttpResponseMessage res = await pc.addProducto(p);
            Assert.IsTrue(res.IsSuccessStatusCode);
        }
    }
}
