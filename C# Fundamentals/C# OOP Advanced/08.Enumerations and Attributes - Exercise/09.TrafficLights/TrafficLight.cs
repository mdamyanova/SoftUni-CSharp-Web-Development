using System;

namespace _09.TrafficLights
{
    public class TrafficLight
    {
        public TrafficLight(LightColor currentColor)
        {
            this.CurrentColor = currentColor;
        }

        public LightColor CurrentColor { get; set; }

        public void ChangeColor()
        {
            var color = (int)this.CurrentColor;
            color = (color + 1) % 3;
            this.CurrentColor = (LightColor)Enum.Parse(typeof(LightColor), color.ToString());
        }
    }
}