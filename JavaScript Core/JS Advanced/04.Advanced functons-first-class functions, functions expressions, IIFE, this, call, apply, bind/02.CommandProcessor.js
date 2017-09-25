function commandProcessor(commands) {
    let commandProccessor = (function proccessCommands() {
        let text = '';

        return {
            append: (str) => text += str,
            print: () => console.log(text),
            removeStart: (count) => text = text.slice(count),
            removeEnd: (count) => text = text.slice(0, text.length - count)
        };
    })();

    for (let commandArgs of commands) {
        let [command, args] = commandArgs.split(' ');
        commandProccessor[command](args);
    }
}