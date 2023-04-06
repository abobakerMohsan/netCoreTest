using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage.Entities
{
    public class Branche
    {
       public Guid Id { get; set; }
      //  public Guid BrancheId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string? Region { get; set; }

        public string? PostalCode { get; set; }
   
  

        public ICollection<Employe> Employes { get; private set; }

    }
    
}
