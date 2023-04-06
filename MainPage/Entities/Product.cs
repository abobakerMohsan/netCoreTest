using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage.Entities
{
    public class Product
    {


        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
       public ICollection<SizeProduct> Sizes { get; set; }


    }
    
}
