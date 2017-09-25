function extractLinks(arr) {
    let regex = /www\.[A-Za-z0-9\-]+\.[a-z]+(?:\.[a-z]+)*/g;
    let result = [];

    for(let line of arr){
        let match = regex.exec(line);
        while(match){
            result.push(match);
            match = regex.exec(line);
        }
    }
    return result.join('\n');
}