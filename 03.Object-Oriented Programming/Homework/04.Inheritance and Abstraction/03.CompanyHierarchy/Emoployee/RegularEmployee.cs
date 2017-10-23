using _03.CompanyHierarchy.Interface;

namespace _03.CompanyHierarchy.Emoployee
{
    public abstract class RegularEmployee : Employee, IRegularEmployee
    {
        protected RegularEmployee(int id, string firstName, string lastName, decimal salary, string department) : 
            base(id, firstName, lastName, salary, department)
        {
        }
    }
}