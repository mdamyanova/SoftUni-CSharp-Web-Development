function solve () {
    function computerQualityMixin (classToExtend) {
        let asQualityMixin = function () {
            this.getQuality = function () {
                return (this.processorSpeed + this.ram + this.hardDiskSpace) / 3;
            };
            this.isFast = function () {
                if (this.processorSpeed > (this.ram / 4)) {
                    return true;
                }

                return false;
            };
            this.isRoomy = function () {
                if (this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed)) {
                    return true;
                }

                return false;
            };

            return this;
        };

        asQualityMixin.call(classToExtend.prototype);
    }

    function styleMixin (classToExtend) {
        let asStyleMixin = function () {
            this.isFullSet = function () {
                if (this.keyboard.manufacturer === this.monitor.manufacturer) {
                    return true;
                }

                return false;
            };
            this.isClassy = function () {
                if (this.battery.expectedLife >= 3) {
                    if (this.color.toLowerCase() === 'silver' || this.color.toLowerCase() === 'black') {
                        if (this.weight <= 3) {
                            return true;
                        }
                    }
                }

                return false;
            };

            return this;
        };

        asStyleMixin.call(classToExtend.prototype);
    }

    return {
        computerQualityMixin,
        styleMixin
    };
}