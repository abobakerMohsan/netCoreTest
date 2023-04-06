using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage.Entities
{
    public class SizeProduct
    {
        public Guid Id { get; set; }
      //  public Guid SizeId { get; set; }
      
        public float SizePrice { get; set; }

        public Guid ProductId { get; set; }
        public Guid SizeId { get; set; }

        public Product Product { get; set; }
        public Size Size { get; set; }
  

    }
    
}
