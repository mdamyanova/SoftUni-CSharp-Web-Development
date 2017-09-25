function minkaTheJSGoddess(arr) {
    var data = {};
    arr.forEach(function (el) {
        var lineArgs = el.trim().split(/\s+&\s+/g);
        var task = 'Task ' + lineArgs[2];
        if (!data[task]) {
            data[task] = {
                tasks: [],
                average: 0,
                lines: 0
            };
        }

        data[task].tasks.push({
            name: lineArgs[0],
            type: lineArgs[1]
        });
        data[task].average += Number(lineArgs[3]);
        data[task].lines += Number(lineArgs[4]);
    });

    Object.keys(data).forEach(function (key) {
        data[key].average = parseFloat((data[key].average / data[key].tasks.length).toFixed(2));
        data[key].tasks.sort(function (a, b) {
            return a.name.localeCompare(b.name);
        });
    });

    var keysSorted = Object.keys(data).sort(function (a, b) {
        if (data[a].average == data[b].average) {
            return data[a].lines - data[b].lines;
        }

        return data[b].average - data[a].average;
    });

    var sortedObject = {};
    keysSorted.forEach(function (el) {
        sortedObject[el] = data[el];
    });

    console.log(JSON.stringify(sortedObject));
}