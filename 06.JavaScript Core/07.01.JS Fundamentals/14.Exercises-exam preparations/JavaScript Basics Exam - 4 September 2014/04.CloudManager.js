function cloudManager(input) {
    var results = [];

    for (let i = 0; i < input.length; i++) {
        let data = input[i].split(/\s+/);
        let file = data[0];
        let extension = data[1];
        let memory = parseFloat(data[2]);
        if (!results[extension]) {
            results[extension] = { files: [], memory: [] };
        }
        results[extension].files.push(file);
        results[extension].memory.push(memory);
    }


    for (let key in results) {
        results[key].memory = getAvg(results[key].memory);
        results[key].files.sort();
    }

    let output = [];
    let keys = Object.keys(results);
    keys.sort();
    for (let i = 0; i < keys.length; i++) {
        output[keys[i]] = results[keys[i]];
    }
    let outputObj = toObject(output);
    console.log(JSON.stringify(outputObj));

    function getAvg(arr) {
        let sum = 0;
        for (let i = 0; i < arr.length; i++) {
            sum += arr[i];
        }
        return sum.toFixed(2);
    }

    function toObject(arr) {
        let obj = { };
        for (let key in arr) {
            obj[key] = arr[key];
        }
        return obj;
    }
}