function cars(inputArray) {
    let cars = new Map();

    let carManager = {
        create: ([carName, secondCommand, parent]) => {
            parent = parent ? cars.get(parent) : null;
            let newCar = Object.create(parent);
            cars.set(carName, newCar);
            return newCar;
        },
        set: ([carName, key, value]) => {
            let targetCar = cars.get(carName);
            targetCar[key] = value;
        },
        print: ([carName]) => {
            let targetCar = cars.get(carName);
            let keys = []
            let childKeys = Object.keys(targetCar);
            keys.push.apply(keys, childKeys);
            let firstParent = Object.getPrototypeOf(targetCar);

            let parent = Object.getPrototypeOf(targetCar);
            while (parent) {
                let parentKeys = Object.keys(parent);
                keys.push.apply(keys, parentKeys);
                parent = Object.getPrototypeOf(parent);
            }

            let resultString = keys.map((key) => `${key}:${targetCar[key]}`).join(', ');
            console.log(resultString);
        }
    };

    for (let lineArguments of inputArray) {
        let currentArgs = lineArguments.split(' ');
        let command = currentArgs.shift();
        carManager[command](currentArgs);
    }
}