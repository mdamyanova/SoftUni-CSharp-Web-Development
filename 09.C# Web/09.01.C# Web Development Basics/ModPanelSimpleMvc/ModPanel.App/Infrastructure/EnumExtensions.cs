namespace ModPanel.App.Infrastructure
{
    using Data.Models;
    using System;

    public static class EnumExtensions
    {
        public static string ToFriendlyName(this Position position)
        {
            switch (position)
            {
                case Position.Developer:
                case Position.Designer:
                case Position.HR:
                    return position.ToString();
                case Position.TechnicalSupport:
                    return "Technical Support";
                case Position.TechnicalTrainer:
                    return "Technical Trainer";
                case Position.MarketingSpecialist:
                    return "Marketing Specialist";
                default:
                    throw new InvalidOperationException($"Invalid position type {position}.");
            }
        }

        public static string ToViewClassName(this LogType type)
        {
            switch (type)
            {
                case LogType.CreatePost:
                    return "success";
                case LogType.EditPost:
                    return "warning";
                case LogType.DeletePost:
                    return "danger";
                case LogType.UserApproval:
                    return "success";
                case LogType.OpenMenu:
                    return "primary";
                default:
                    throw new InvalidOperationException($"Invalid log type {type}.");
            }
        }
    }
}
