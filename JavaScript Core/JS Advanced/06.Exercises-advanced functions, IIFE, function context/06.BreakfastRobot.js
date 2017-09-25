let breakfastManager = (function () {
    let resources = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    let products = {
        apple: { carbohydrate: 1, flavour: 2 },
        coke: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        omelet: { protein: 5, fat: 1, flavour: 1 },
        cheverme: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    };

    function restock (resource, quantity) {
        resources[resource] += Number(quantity);
        return 'Success';
    }

    function report() {
        return [...Object.keys(resources)].map(x => x + '=' + resources[x]).join(' ');
    }

    function prepare (recipe, quantity) {
        quantity = Number(quantity);
        for (let index in products[recipe]) {
            let currentTotalResource = resources[index];
            let neededResource = products[recipe][index] * quantity;

            if (currentTotalResource < neededResource) {
                return `Error: not enough ${index} in stock`;
            }
        }

        for (let index in products[recipe]) {
            resources[index] -= products[recipe][index] * quantity;
        }

        return 'Success';
    }

    return function commandProcessor (input) {
        let inputArgs = input.split(' ');
        let command = inputArgs.shift();

        if (command === 'restock') {
            return restock(...inputArgs);
        } else if (command === 'report') {
            return report();
        } else if (command === 'prepare') {
            return prepare(...inputArgs);
        }
    };
})();