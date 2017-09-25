function JSONsTable(input) {
    let objects = [];
    for(let obj of input){
        objects.push(JSON.parse(obj));
    }
    let html = '<table>\n';
    for(let object of objects){
        html += '\t<tr>\n';
        for(let key of Object.keys(object)){
            html += `\t<td>${htmlEscape(object[key])}</td>\n`;
        }
        html += '\t<tr>\n';
    }
    html += '</table>';
    return html;

    function htmlEscape(text) {
        text = text.toString();
        let map = { '"': '&quot;', '&': '&amp;', "'": '&#39;', '<': '&lt;', '>': '&gt;' };
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }
}