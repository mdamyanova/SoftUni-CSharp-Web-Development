function carFactory(inputCarObject) {
    let engines = {
        small: { power: 90, volume: 1800 },
        normal: { power: 120, volume: 2400 },
        monster: {power: 200, volume: 3500 }
    };

    let carriageTypes = {
        hatchback: { type: 'hatchback', color: inputCarObject.color },
        coupe: { type: 'coupe', color: inputCarObject.color }
    };

    let resultObject = {
        model: inputCarObject.model,
        engine: getEngine(inputCarObject.power),
        carriage: carriageTypes[inputCarObject.carriage],
        wheels: getWheels(inputCarObject.wheelsize)
    };

    return resultObject;

    function getEngine (enginePower) {
        if (enginePower <= 90) {
            return engines.small;
        } else if (enginePower <= 120) {
            return engines.normal;
        } else {
            return engines.monster;
        }
    }

    function getWheels (wheelsDiameter) {
        if (wheelsDiameter % 2 === 0) {
            --wheelsDiameter;
            return [wheelsDiameter, wheelsDiameter, wheelsDiameter, wheelsDiameter];
        }

        return [wheelsDiameter, wheelsDiameter, wheelsDiameter, wheelsDiameter]
    }
}