function balloons() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }
    }

    class PartyBallon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            this.ribbonColor = ribbonColor;
            this.ribbonLength = ribbonLength;
            this._ribbon = {color: ribbonColor, length: ribbonLength};
        }

        get ribbon() {
            return this._ribbon;
        }
    }

    class BirthdayBallon extends PartyBallon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength);
            this._text = text;
        }

        get text() {
            return this._text;
        }
    }

    return {Balloon, PartyBalloon, BirthdayBalloon};
}