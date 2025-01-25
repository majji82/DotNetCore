using System.ComponentModel.DataAnnotations;

namespace ProductCrud.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Url(ErrorMessage = "Please provide a valid URL")]
        public string? ImageURL {  get; set; }
    }
}
