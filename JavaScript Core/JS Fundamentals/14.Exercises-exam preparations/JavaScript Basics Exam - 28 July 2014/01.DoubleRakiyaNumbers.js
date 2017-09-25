function doubleRakiyaNumbers(input) {
    let start = Number(input[0]);
    let end = Number(input[1]);
    let html = '<ul>\n';
    for(let num = start; num <= end; num++){
        if(isDoubleRakiyaNum(num)){
            html += `<li><span class='rakiya'>${num}</span><a href=\"view.php?id=${num}\>View</a></li>\n`;
        } else {
            html += `<li><span class='num'>${num}</span></li>\n`;
        }
    }
    html += '</ul>\n';
    return html;

    function isDoubleRakiyaNum(num) {
        let numString = '' + num;
        let existingPairs = {};
        for(let i = 1; i < numString.length; i++){
            let pair = numString.substr(i - 1, 2);
            if(existingPairs[pair]){
                if(i - existingPairs[pair] >= 2){
                    return true;
                }
            } else {
                existingPairs[pair] = i;
            }
        }
        return false;
    }
}