function cappyJuice(input) {
    let juices = new Map();
    let result = new Map();
    for (let line of input) {
        line = line.split(/\s*=>\s*/);
        if (juices.has(line[0])) {
            juices.set(line[0], juices.get(line[0]) + Number(line[1]))
        } else {
            juices.set(line[0], Number(line[1]))
        }

        checkForBottles();
    }

    function checkForBottles() {
        for (let [juice, quantity] of juices) {
            if (quantity >= 1000) {
                if (result.has(juice)) {
                    result.set(juice, result.get(juice) + Math.floor(quantity / 1000));
                } else {
                    result.set(juice, Math.floor(quantity / 1000));
                }
                juices.set(juice, juices.get(juice) % 1000);
            }
        }
    }

    for(let [juice, bottles] of result){
        console.log(`${juice} => ${bottles}`)
    }
}