function solve () {
    class Keyboard {
        constructor (manufacturer, responseTime) {
            this.manufacturer = manufacturer;
            this.responseTime = responseTime;
        }
    }

    class Monitor {
        constructor (manufacturer, width, height) {
            this.manufacturer = manufacturer;
            this.width = width;
            this.height = height;
        }
    }

    class Battery {
        constructor (manufacturer, expectedLife) {
            this.manufacturer = manufacturer;
            this.expectedLife = expectedLife;
        }
    }

    class Computer {
        constructor (manufacturer, processorSpeed, ram, hardDiskSpace) {
            if (new.target === Computer) {
                throw Error('Cannot create an istance of an abstract class');
            }

            this.manufacturer = manufacturer;
            this.processorSpeed = processorSpeed;
            this.ram = ram;
            this.hardDiskSpace = hardDiskSpace;
        }
    }

    class Laptop extends Computer {
        constructor (manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.weight = weight;
            this.color = color;
            this.battery = battery;
        }

        get battery () {
            return this._battery;
        }

        set battery (newBattery) {
            if (newBattery instanceof Battery) {
                this._battery = newBattery;
            } else {
                throw new TypeError();
            }
        }
    }

    class Desktop extends Computer {
        constructor (manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.keyboard = keyboard;
            this.monitor = monitor;
        }

        get keyboard () {
            return this._keyboard;
        }

        set keyboard (newKeyboard) {
            if (newKeyboard instanceof Keyboard) {
                this._keyboard = newKeyboard;
            } else {
                throw new TypeError();
            }
        }

        get monitor () {
            return this._monitor;
        }

        set monitor (newMonitor) {
            if (newMonitor instanceof Monitor) {
                this._monitor = newMonitor;
            } else {
                throw new TypeError();
            }
        }
    }

    return {
        Battery,
        Keyboard,
        Monitor,
        Computer,
        Laptop,
        Desktop
    };
}