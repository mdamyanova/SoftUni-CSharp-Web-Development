function sortTable(input) {
    let rows = [];
    for(let i = 2; i < input.length - 1; i++){
        let rowData = input[i];
        let regex = /<td>.*?<\/td><td>(.*?)<\/td>/g;
        let match = regex.exec(rowData);
        let price = Number(match[1]);
        let row = { price: price, data: rowData };
        rows.push(row);
    }

    // sort objects by price
    rows.sort(function (a, b) {
        if(a.price != b.price){
            return a.price - b.price;
        } else {
            return a.data == b.data ? 0 : a.data < b.data ? -1 : 1;
        }
    });
    console.log(input[0]);
    console.log(input[1]);
    for(let i = 0; i < rows.length; i++){
        console.log(rows[i].data);
    }
    console.log(input[input.length - 1]);
}