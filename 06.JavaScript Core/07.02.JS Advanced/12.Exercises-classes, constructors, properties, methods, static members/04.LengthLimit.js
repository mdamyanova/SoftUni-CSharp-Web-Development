class Stringer {
    constructor (innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    increase (length) {
        this.innerLength += length;
    }

    decrease (length) {
        this.innerLength -= length;

        if (this.innerLength < 3) {
            this.innerLength = 0;
        }
    }

    toString () {
        if (this.innerString.length > this.innerLength) {
            let charactersToCut = this.innerString.length - this.innerLength;
            return this.innerString.slice(0, this.innerString.length - charactersToCut) + '...';
        } else if (this.innerLength === 0) {
            return  '...';
        }

        return this.innerString;
    }
}