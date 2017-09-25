function sortedList() {
    return (function () {
        let items = [];

        function add (element) {
            items.push(element);
            sort();
        }

        function remove (index) {
            if (!isValidIndex(index)) {
                throw new Error('Index is out of range. index: ' + index);
            }

            items.splice(index, 1);
            sort();
        }

        function get (index) {
            if (!isValidIndex(index)) {
                throw new Error('Index is out of range. index: ' + index);
            }

            sort();
            return items[index];
        }

        function isValidIndex(index) {
            return index >= 0 && index < items.length;
        }

        function sort () {
            items = items.sort((a, b) => a - b);
        }

        function getSize () {
            return items.length;
        }

        let sortedList = {
            add,
            remove,
            get
        };

        sortedList.__defineGetter__("size", getSize);

        return sortedList;
    })();
}