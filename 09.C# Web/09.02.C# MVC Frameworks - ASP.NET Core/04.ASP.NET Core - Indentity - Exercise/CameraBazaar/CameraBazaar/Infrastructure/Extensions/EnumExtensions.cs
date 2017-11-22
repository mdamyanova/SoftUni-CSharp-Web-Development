namespace CameraBazaar.Infrastructure.Extensions
{
    using Data.Models.Enums;

    public static class EnumExtensions
    {
        public static string ToDisplayName(this LightMetering lightMetering)
        {
            if(lightMetering == LightMetering.Spot)
            {
                return "Spot";
            }
            else if(lightMetering == LightMetering.CenterWeighted)
            {
                return "Center-Weighted";
            }
            else
            {
                return "Evaluative";
            }
        }
    }
}