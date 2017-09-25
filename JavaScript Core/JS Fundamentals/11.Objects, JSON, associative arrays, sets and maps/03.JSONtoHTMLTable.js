function JSONToHTMLTable([json]) {
    let html = '<table>\n';
    let arr = JSON.parse(json);
    html += '\t<tr>';

    for(let key of Object.keys(arr[0])){
        html += `<th>${htmlEscape(key)}</th>`;
    }
    html += '</tr>\n';


    for(let obj of arr){
        html += '\t<tr>';
        for(let key of Object.keys(obj)){
            html += `<td>${htmlEscape(obj[key])}</td>`;
        }
        html += '</tr>\n';
    }

    html += '</table>';
    return html;

    function htmlEscape(text) {
        text = text.toString();
        let map = { '"': '&quot;', '&': '&amp;', "'": '&#39;', '<': '&lt;', '>': '&gt;' };
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }
}

console.log(JSONToHTMLTable([{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]));