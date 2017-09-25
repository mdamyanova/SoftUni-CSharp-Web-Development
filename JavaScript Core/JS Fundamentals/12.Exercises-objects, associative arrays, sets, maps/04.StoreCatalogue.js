function generateStoreCatalogue(data) {
    let catalogue = new Map;
    for (let line of data) {
        let tokens = line.split(/\s:\s/);
        let [product, price] = [tokens[0], Number(tokens[1])];
        let productFirstLetter = product[0].toUpperCase();
        if (!catalogue.has(productFirstLetter)) {
            catalogue.set(productFirstLetter, []);
        }

        catalogue.get(productFirstLetter).push({title: product, value: price});
    }

    function customComparator(productA, productB) {
        return productA.title.toLowerCase().localeCompare(productB.title.toLowerCase());
    }

    let sortedCategories = [...catalogue.keys()].sort();
    for (let category of sortedCategories) {
        console.log(category);
        let products = catalogue.get(category).sort(customComparator);
        products.forEach(p => console.log(`  ${p.title}: ${p.value}`));
    }
}