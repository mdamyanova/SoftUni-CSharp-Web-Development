function autoEngineeringCompany(input) {
    let result = new Map;
    for(let line of input){
        line = line.split(' | ');
        let brand = line[0];
        let model = line[1];
        let cars = Number(line[2]);

        // if we don't have the brand, add a new brand
        if(!result.has(brand)) {
            result.set(brand, new Map);
        }

        // check if we have the model
        if(!result.get(brand).has(model)){
            result.get(brand).set(model, 0);
        }

        result.get(brand).set(model, result.get(brand).get(model) + cars);

    }

    for(let [brand, models] of result){
        console.log(brand);
        for(let [model, cars] of models){
            console.log(`###${model} -> ${cars}`);
        }
    }
}