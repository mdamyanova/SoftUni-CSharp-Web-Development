using System.Collections.Generic;
using _03.CompanyHierarchy.Emoployee;

namespace _03.CompanyHierarchy.Interface
{
    public interface ISalesEmployee
    {
         List<Sale> Sales { get; set; } 
    }
}