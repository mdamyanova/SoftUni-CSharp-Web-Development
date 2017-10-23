using System;
using System.Collections.Generic;

namespace _02.Customer
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private readonly IList<Payment> payments;
        private CustomerType customerType;

        public Customer(
            string firstName,
            string middleName,
            string lastName,
            string id,
            string permanentAddress,
            string mobilePhone,
            string email,
            CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;      
            this.CustomerType = customerType;
            this.payments = new List<Payment>();
        }

        public string FirstName { get; }

        public string MiddleName { get; }

        public string LastName { get; }

        public string Id { get; }

        public string PermanentAddress { get; private set; }

        public string MobilePhone { get; private set; }

        public string Email { get; private set; }

        public IEnumerable<Payment> Payments => this.payments;

        public CustomerType CustomerType { get; }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            if (customer == null)
            {
                return false;
            }
            if (!object.Equals(this.FirstName, customer.FirstName) ||
                !object.Equals(this.MiddleName, customer.MiddleName) ||
                !object.Equals(this.LastName, customer.LastName))
            {
                return false;
            }

            if (this.Id != customer.Id)
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            return Customer.Equals(customer1, customer2);
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(Customer.Equals(customer1, customer2));
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ Id.GetHashCode();
        }

        public void AddPayment(Payment payment)
        {
           this.payments.Add(payment);
        }

        public object Clone()
        {
            var newCustomer = new Customer(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.Id,
                this.PermanentAddress,
                this.MobilePhone,
                this.Email,
                this.CustomerType);

            foreach (var payment in this.payments)
            {
                newCustomer.AddPayment(payment);
            }

            return newCustomer;
        }

        public int CompareTo(Customer other)
        {
            var comparator = string.Compare($"{this.FirstName} {this.MiddleName} {this.LastName}", $"{other.FirstName} {other.MiddleName} {other.LastName}", StringComparison.Ordinal);

            return comparator == 0 ? this.Id.CompareTo(other.Id) : comparator;
        }

        public override string ToString()
        {
            var output = $"Customer: {this.FirstName} {this.MiddleName} {this.LastName}{Environment.NewLine}";
            output += $"ID: {this.Id}{Environment.NewLine}";
            output += $"Permanent address: {this.PermanentAddress}{Environment.NewLine}";
            output += $"Mobile phone: {this.MobilePhone}, E-mail: {this.Email}{Environment.NewLine}";
            foreach (var payment in this.Payments)
            {
                output += payment;
            }
            output += $"Customer type: {this.CustomerType}{Environment.NewLine}";

            return output;
        }
    }
}