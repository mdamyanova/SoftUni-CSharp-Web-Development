namespace List_Processing.Core.Models
{
    using System.Collections.Generic;

    public class Data
    {
        public Data()
        {
            this.EndReceived = false;
        }

        public List<string> DataParams { get; set; } = new List<string>();

        public bool EndReceived { get; set; }
    }
}