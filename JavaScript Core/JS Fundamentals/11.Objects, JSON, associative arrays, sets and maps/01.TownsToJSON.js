function townsToJson(input) {
    // removes the first line which is towns|lat|long
    input = input.splice(1);
    let result = [];
    for(let line of input){
        line = line.split(/\s*\|\s*/);
        let obj = { Town:line[1].trim(), Latitude: Number(line[2].trim()), Longitude: Number(line[3].trim()) };
        result.push(obj);
    }
    console.log(JSON.stringify(result));
}