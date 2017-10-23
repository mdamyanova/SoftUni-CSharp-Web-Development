function addAndRemoveElements(input) {
    let arr = [];
    let count = 0;
    for (let command of input) {
        if (command == 'add') {
            arr.push(count + 1);
        } else {
            arr.pop();
        }
        count++;
    }
    console.log(arr.length == 0 ? 'Empty' : arr.join('\n'));
}