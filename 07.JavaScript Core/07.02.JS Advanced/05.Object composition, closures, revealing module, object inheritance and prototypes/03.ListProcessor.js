function listProcessor(inputArray) {
    let processCommand = (() => {
        let items = [];
        return {
            add: (str) => items.push(str),
            remove: (str) => items = items.filter(item => item !== str),
            print: () => console.log(items.join(','))
        }
    })();

    for (let item of inputArray) {
        let itemArgs = item.split(' ');
        processCommand[itemArgs[0]](itemArgs[1]);
    }
}