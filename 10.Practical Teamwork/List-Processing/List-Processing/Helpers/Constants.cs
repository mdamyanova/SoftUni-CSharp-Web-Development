namespace List_Processing.Helpers
{
    public class Constants
    {
        public const string InvalidParameters = "Error: invalid command parameters.";
        public const string InvalidCommand = "Error: invalid command";
        public const string InvalidIndex = "Error: invalid index";
        public const string FinishedMessage = "Finished";

        public const string AppendCommandName = "append";
        public const int AppendCommandLength = 2;

        public const string PrependCommandName = "prepend";
        public const int PrependCommandLength = 2;

        public const string ReverseCommandName = "reverse";
        public const int ReverseCommandLength = 1;

        public const string InsertCommandName = "insert";
        public const int InsertCommandLength = 3;

        public const int RollCommandLength = 2;

        public const int SortCommandLength = 1;

        public const string DeleteCommandName = "delete";
        public const int DeleteCommandLength = 2;

        public const int CountCommandLength = 2;
    }
}