using System;

namespace _03.CompanyHierarchy.Interface
{
    public interface IProject
    {
        string ProjectName { get; set; }

        DateTime StartDate { get; set; }

        string Details { get; set; }

        string State { get; }

        void CloseProject();
    }
}