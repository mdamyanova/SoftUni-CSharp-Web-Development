function extractHyperlinks(input){
    let html = input.join('\n');
    let regex = /<a\s+([^>]+\s+)?href\s*=\s*('([^']*)'|"([^"]*)|([^\s>]+))[^>]*>/g;
    let match;
    while(match = regex.exec(html)){
        let hrefVal = match[3];
        if(hrefVal == undefined){
            hrefVal = match[4];
        }
        if(hrefVal == undefined){
            hrefVal = match[5];
        }
        console.log(hrefVal);
    }
}