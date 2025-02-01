using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServiceTask.Api.Models.Customer
{
    public class CreateCustomerModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
    }
}
