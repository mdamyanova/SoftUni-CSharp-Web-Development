function parseJSON(arr) {
    for (let i = 0; i < arr.length; i++) {
        let line = JSON.parse(arr[i]);
        console.log("Name: " + line.name);
        console.log("Age: " + line.age);
        console.log("Date: " + line.date);
    }
}