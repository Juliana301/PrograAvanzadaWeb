
using System.ComponentModel.DataAnnotations;


namespace APW.Models
{
        public class ProductViewModel
        {

            public int Id { get; set; }

            [Required(ErrorMessage = "Name is required")]
            public string Name { get; set; }

            [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]

            public decimal Price { get; set; }

            public int? CategoryId { get; set; }

            public string CategoryName { get; set; }
        }
    }



