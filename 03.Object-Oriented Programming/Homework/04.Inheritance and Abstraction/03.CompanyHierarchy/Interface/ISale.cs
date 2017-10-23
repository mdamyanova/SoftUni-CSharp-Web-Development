using System;
using System.Linq.Expressions;

namespace _03.CompanyHierarchy.Interface
{
    public interface ISale
    {
        string ProductName { get; set; }

        DateTime Date { get; set; }
        
        decimal Price { get; set; }
    }
}