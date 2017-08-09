namespace _01.Logger.Models.Layouts
{
    using System;
    using System.Text;
    using _01.Logger.Interfaces;

    public class XmlLayout : ILayout
    {
        public string Format(string message, ReportLevel level, DateTime dateTime)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine($"<date>{dateTime}</date>");
            sb.AppendLine($"<level>{level}</level>");
            sb.AppendLine($"<message>{message}</message>");
            sb.AppendLine("</log>");

            return sb.ToString();
        }
    }
}