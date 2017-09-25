function concerts(input) {
    let concertInfo = {};
    for (let index in input) {
        let tokens = input[index].split('|');
        let band = tokens[0].trim();
        let town = tokens[1].trim();
        let date = tokens[2].trim();
        let venue = tokens[3].trim();

        if (!concertInfo[town]) {
            concertInfo[town] = {};
        }
        if (!concertInfo[town][venue]) {
            concertInfo[town][venue] = [];
        }
        if (concertInfo[town][venue].indexOf(band) == -1) {
            concertInfo[town][venue].push(band);
        }
    }

    concertInfo = sortObjectProperties(concertInfo);
    for (let town in concertInfo) {
        concertInfo[town] = sortObjectProperties(concertInfo[town]);
        for (let venue in concertInfo[town]) {
            concertInfo[town][venue].sort();
        }
    }

    console.log(JSON.stringify(concertInfo));

    // sort alphabetically
    function sortObjectProperties(obj) {
        let keysSorted = Object.keys(obj).sort();
        let sortedObj = {};
        for (let i = 0; i < keysSorted.length; i++) {
            let key = keysSorted[i];
            sortedObj[key] = obj[key];
        }
        return sortedObj;
    }
}