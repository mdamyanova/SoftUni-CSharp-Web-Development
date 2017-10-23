class SortedList {
    constructor () {
        this.items = [];
        this.size = 0;
    }

    add (item) {
        this.items.push(item);
        this.size = this.items.length;
        this.sort();
    }
    remove (index) {
        if (index >= 0 && index < this.size) {
            this.items.splice(index, 1);
            this.size = this.items.length;
            this.sort();
        }
    }
    get (index) {
        if (index >= 0 && index < this.size) {
            return this.items[index];
        }
    }
    sort () {
        this.items.sort((a, b) => a - b);
    }
}