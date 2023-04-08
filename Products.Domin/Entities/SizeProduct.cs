using Products.Domain.Entities;

namespace Products.Domain.Entites
{
    public class SizeProduct
    {
        public Guid Id { get; set; }
      //  public Guid SizeId { get; set; }
      
        public float SizePrice { get; set; }

        public Guid ProductId { get; set; }
        public Guid SizeId { get; set; }

        public Product Product { get; set; }
        public MainSize Size { get; set; }
  

    }
    
}
