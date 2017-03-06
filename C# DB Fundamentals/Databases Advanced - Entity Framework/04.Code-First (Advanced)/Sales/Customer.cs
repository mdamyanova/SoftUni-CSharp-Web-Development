using System.Collections;
using System.Collections.Generic;

namespace Sales
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public List<Sale> SalesForCustomer { get; set; }
    }
}