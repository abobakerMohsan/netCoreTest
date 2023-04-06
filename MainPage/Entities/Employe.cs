using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage.Entities
{
    public class Employe
    {


        public Guid Id { get; set; }
        // public Guid EmployeeId { get; set; }
        public int? UserId { get; set; }

        public Guid BranchesId { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; }
      
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }

        public string? Phone { get; set; }
        public string? Address { get; set; }

        public string? Notes { get; set; }

        public Branche Branche { get; set; }

        public User User { get; set; }
   

    }
    
}
