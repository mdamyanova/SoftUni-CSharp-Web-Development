using System;

namespace _04.StudentClass
{
    public class PropertyChangedEventArgs : EventArgs
    {
        public PropertyChangedEventArgs(object prevValue, object newValue, string propName)
        {
            this.PrevValue = prevValue;
            this.NewValue = newValue;
            this.PropName = propName;
        }

        public object PrevValue { get; private set; }

        public object NewValue { get; private set; }

        public string PropName { get; private set; }
    }
}