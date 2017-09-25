function solve () {
    class Melon {
        constructor (weight, melonSort) {
            if (new.target === Melon) {
                throw new Error('Abstract class cannot be instantiated directly');
            }
            this.weight = weight;
            this.melonSort  = melonSort;
        }

        toString () {
            return `Element: ${this.elementYani}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }

        get elementIndex () {
            return this.weight * this.melonSort.length;
        }
    }

    class Watermelon extends Melon {
        constructor (weight, melonSort) {
            super(weight, melonSort);
            this.elementYani = 'Water';
        }
    }

    class Firemelon extends Melon {
        constructor (weight, melonSort) {
            super(weight, melonSort);
            this.elementYani = 'Fire';
        }
    }

    class Earthmelon extends Melon {
        constructor (weight, melonSort) {
            super(weight, melonSort);
            this.elementYani = 'Earth';
        }
    }

    class Airmelon extends Melon {
        constructor (weight, melonSort) {
            super(weight, melonSort);
            this.elementYani = 'Air';
        }
    }

    class Melolemonmelon extends Firemelon {
        constructor (weight, melonSort) {
            super(weight, melonSort);
            this.elements = ['Water', 'Fire', 'Earth', 'Air'];
            this.elementYani = 'Water';
        }

        morph () {
            this.elements.push(this.elements.shift());
            this.elementYani = this.elements[0];
            return this;
        }
    }

    return {
        Melon,
        Watermelon,
        Firemelon,
        Earthmelon,
        Airmelon,
        Melolemonmelon
    };
}