function turnObjToJSON(arr) {
    let object = {};
    for (let i = 0; i < arr.length; i++) {
        let s = arr[i].split(" -> ");
        let key = s[0];
        let value = s[1];
        if (!isNaN(value))
            value = parseInt(value);
        object[key] = value;
    }
    let toString = JSON.stringify(object);
    console.log(toString);
}