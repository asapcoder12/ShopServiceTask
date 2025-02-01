using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServiceTask.DataAccess.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public virtual List<Purchase> Purchases { get; set; }
    }
}
