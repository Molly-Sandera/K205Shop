using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string SKU { get; set; }
        public int CategoryId { get; set; }
        public string CoverPhoto { get; set; }
        public bool IsSlider { get; set; }
    }
}
