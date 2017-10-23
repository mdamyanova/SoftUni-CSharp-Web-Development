using System;

namespace _03.GenericList._04.VersionAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct |
        AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]
    public class VersionAttribute : Attribute
    {
        private int minor;
        private int major;

        public VersionAttribute(int minor, int major)
        {
            this.Minor = minor;
            this.Major = major;
        }

        public int Minor
        {
            get { return this.minor; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Minor value of the attribute cannot be negative");
                }
                this.minor = value;
            }
        }

        public int Major
        {
            get { return this.major; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Major value of the attribute cannot be negative");
                }
                this.major = value;
            }
        }

        public override string ToString()
        {
            string result = $"Version {this.Major}.{this.Minor.ToString("X2")}";

            return result;
        }
    }
}