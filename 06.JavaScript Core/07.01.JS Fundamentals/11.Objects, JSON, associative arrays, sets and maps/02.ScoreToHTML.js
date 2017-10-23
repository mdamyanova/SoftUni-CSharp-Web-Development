function scoreToHTMLTable(scoreJSON) {
    let arr = JSON.parse(scoreJSON);

    let html = '<table>\n';
    html += `\t<tr><th>name</th><th>score</th></tr>\n`;
    for (let obj of arr){
        html += `\t<tr><td>${htmlEscape(obj['name'])}</td><td>${obj['score']}</td></tr>\n`;
    }
    html += "</table>";
    return html;

    function htmlEscape(text) {
        text = text.toString();
        let map = { '"': '&quot;', '&': '&amp;', "'": '&#39;', '<': '&lt;', '>': '&gt;' };
        return text.replace(/[\"&'<>"]/g, ch => map[ch]);
    }
}