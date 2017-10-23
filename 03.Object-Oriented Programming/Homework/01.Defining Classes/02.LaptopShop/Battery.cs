using System;

namespace _02.LaptopShop
{
    public class Battery
    {
        private int cells;
        private int mah;
        private string batteryType;

        public Battery(int cells, int mah, string batteryType)
        {
            this.Cells = cells;
            this.Mah = mah;
            this.BatteryType = batteryType;
        }

        public int Cells
        {
            get { return this.cells; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Battery cells cannot be negative!");
                }
                this.cells = value;
            }
        }

        public int Mah
        {
            get { return this.mah; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Battery mAh cannot be negative!");
                }
                this.mah = value;
            }
        }

        public string BatteryType
        {
            get { return this.batteryType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Battery type cannot be empty!");
                }
                this.batteryType = value;
            }
        }

        public override string ToString()
        {
            return $"{this.BatteryType}, {this.Cells}-cells, {this.Mah} mAh";
        }
    }
}