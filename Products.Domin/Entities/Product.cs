namespace Products.Domain.Entites
{
    public class Product
    {


        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
       public ICollection<SizeProduct> Sizes { get; set; }


    }
    
}
