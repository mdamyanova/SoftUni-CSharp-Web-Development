function cityMarkets(sales) {
    let towns = new Map();
    for (let sale of sales) {
        let [town, product, quantityPrice] = sale.split(/\s*->\s*/);
        let [quantity, price] = quantityPrice.split(/\s*:\s*/);
        if (!towns.has(town))
            towns.set(town, new Map());
        let income = quantity * price;
        let oldIncome = towns.get(town).get(product);
        if (oldIncome) income += oldIncome;
        towns.get(town).set(product, income);
    }
    let print='';

    for (let [index, value] of towns){
        print+=(`Town - ${index}\n`);
        for (let [product, price] of towns.get(index)){
            print+=(`$$$${product} : ${price}\n`);
        }
    }
    return print;
}