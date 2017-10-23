using System;

namespace _02.LaptopShop
{
    public class LaptopShop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphicsCard;
        private int hdd;
        private string screen;
        private Battery battery;
        private double batteryLife;
        private double price;

        public string Model
        {
            get { return this.model; }
            set
            {
                if (value?.Trim().Length == 0)
                {
                    throw new ArgumentNullException("Model cannot be empty!");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (value?.Trim().Length == 0)
                {
                    throw new ArgumentNullException("Manufacturer cannot be empty!");
                }
                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get { return this.processor; }

            set
            {
                if (value?.Trim().Length == 0)
                {
                    throw new ArgumentNullException("Processor name cannot be empty!");
                }
                this.processor = value;
            }
        }

        public int Ram
        {
            get { return this.ram; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("RAM cannot be negative!");

                }
                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get { return this.graphicsCard; }
            set
            {
                if (value?.Trim().Length == 0)
                {
                    throw new ArgumentNullException("Graphics Card cannot be empty!");
                }
                this.graphicsCard = value;
            }
        }

        public int Hdd
        {
            get { return this.hdd; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("HDD cannot be negative!");
                }
                this.hdd = value;
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (value?.Trim().Length == 0)
                {
                    throw new ArgumentNullException("Screen cannot be empty!");
                }
                this.screen = value;
            }
        }

        public Battery Battery { get; set; }

        public double BatteryLife
        {
            get { return this.batteryLife; }
            set
            {
                if (batteryLife < 0)
                {
                    throw new ArgumentOutOfRangeException("Battery life cannot be negative!");
                }
                this.batteryLife = value;
            }
        }

        public double Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative!");
                }
                this.price = value;
            }
        }

        public LaptopShop(string model, string manufacturer, string processor, int ram, string graphicsCard, int hdd,
            string screen, Battery battery, double batteryLife, double price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Battery = battery;
            this.BatteryLife = batteryLife;
            this.Price = price;
        }

        public LaptopShop(string model, string screen, Battery battery, double batteryLife, double price) : this(model, null, null, 0, null, 0, screen, null, 0, price)
        {

        }

        public LaptopShop(string model, double price) : this(model, null, null, 0, price)
        {
            this.Model = model;
            this.Price = price;
        }

        public LaptopShop(string model, string manufacturer, int ram, double price)
            : this(model, manufacturer, null, ram, null, 0, null, null, 0, price)
        {
            
        }

        public override string ToString()
        {
            string output = $"Model: {this.model}\n";
            if (this.Manufacturer != null)
            {
                output += $"Manufacturer: {this.manufacturer}\n";
                output += $"Processor: {this.processor}\n";           
                output += $"RAM: {this.ram}\n";
                output += $"Graphics card: {this.graphicsCard}\n";
                output += $"HDD: {this.hdd}\n";
                output += $"Screen: {this.screen}\n";
                output += $"Battery: {this.battery}\n";
                output += $"Battery life: {this.batteryLife}\n";               
            }
            output += $"Price: {this.price}\n";
            return output;
        }
    }
}