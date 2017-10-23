function heroicInventory(input) {
    // the result is an array of objects, where each object have
    // name, level and array of items
    let heroes = [];
    for(let line of input){
        line = line.split(" / ");
        // check if the hero has items
        let items = line.length > 2 ? line[2].split(', ') : [];
        let object = { name: line[0].trim(), level: Number(line[1].trim()), items: items };
        heroes.push(object);
    }
    return JSON.stringify(heroes);
}