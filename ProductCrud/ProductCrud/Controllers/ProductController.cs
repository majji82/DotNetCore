using Microsoft.AspNetCore.Mvc;
using ProductCrud.Models;
using ProductCrud.Utilities;

namespace ProductCrud.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>()
        {
            new() {Id = 1, Name="Dear Comrade", Description ="Starring Vijay Devarakonda and Rashmika Mandana", Price = 100, ImageURL = "https://i.pinimg.com/736x/06/7a/85/067a85ba3de91c734f44d777ff0a9c3d.jpg"},
            // These both are the same
            new Product{Id = 2, Name="Pushpa The Rule", Description = "Highest Grosser of all Indian Films", Price = 250, ImageURL = "https://wallpapers.com/images/high/puspa-carries-firearm-by-shoulder-xcgee2oi1e6aal0c.webp"},
        };
        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult ViewSingleProduct(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        // Get : To serve the form
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                product.Id = products.Count > 0 ? products.Count + 1 : 1;
                products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Get
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //Post Request
        [HttpPost]
        public IActionResult Edit(int id, Product updatedProduct)
        {
            if(updatedProduct == null)
            {
                return BadRequest("Updated Product is Null!!");
            }

            var product = products.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                product.Name = updatedProduct.Name ?? product.Name;
                product.Description = updatedProduct.Description ?? product.Description;
                product.Price = updatedProduct.Price;
                product.Quantity = updatedProduct.Quantity;
                product.ImageURL = updatedProduct.ImageURL ?? product.ImageURL;

                return RedirectToAction("ViewSingleProduct", new {id = product.Id});
            }
            return View(updatedProduct);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if(product != null)
            {
                products.Remove(product);
            }
            return RedirectToAction("Index");
        }
    }
}
