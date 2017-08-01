using System;

namespace _10._11.InfernoInfinity.Attributes
{
    public class MyClassAttribute : Attribute
    {
        public MyClassAttribute(string author, int revision, string description, string reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; set; }
        public int Revision { get; set; }
        public string Description { get; set; }
        public string Reviewers { get; set; }
    }
}