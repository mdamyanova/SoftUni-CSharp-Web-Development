using System.Collections.Generic;
using _03.CompanyHierarchy.Emoployee;

namespace _03.CompanyHierarchy.Interface
{
    public interface IDeveloper
    {
        List<Project> Projects { get; set; }
    }
}