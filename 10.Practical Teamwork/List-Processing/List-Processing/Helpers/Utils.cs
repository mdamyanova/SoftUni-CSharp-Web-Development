namespace List_Processing.Helpers
{
    using System.Collections.Generic;

    public static class Utils
    {
        public static bool CheckCommandLength(int length, int reqLength)
        {
            if (length != reqLength)
            {
                return false;
            }

            return true;
        }    

        public static string AppendData(IEnumerable<string> collection)
        {
            return string.Join(" ", collection);
        }
    }
}