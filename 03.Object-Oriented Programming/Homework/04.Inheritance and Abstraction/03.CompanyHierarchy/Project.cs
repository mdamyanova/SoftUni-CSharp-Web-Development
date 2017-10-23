using System;
using _03.CompanyHierarchy.Interface;

namespace _03.CompanyHierarchy
{
    public class Project : IProject
    {
        private const string DefaultProjectState = "open";

        private string projectName;

        private DateTime startDate;

        private string details;

        public Project(string projectName, DateTime startDate, string details)
        {
            this.ProjectName = projectName;
            this.StartDate = startDate;
            this.Details = details;
            this.State = DefaultProjectState;

        }

        public string ProjectName
        {
            get { return this.projectName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Project name cannot be empty");
                }
                this.projectName = value;
            }
        }

        public DateTime StartDate { get; set; }

        public string Details { get; set; }

        public string State { get; private set; }

        public void CloseProject()
        {
            this.State = "closed";
        }

        public override string ToString()
        {
            string output =
                $"Project name: {this.ProjectName}\nStart date: {this.StartDate}\nDetails: {this.Details}" +
                $"\nState: {this.State}\n";
            return output;
        }
    }
}