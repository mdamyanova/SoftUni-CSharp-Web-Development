function printAsList(items) {
    console.log('<ul>');
    for (let item of items) {
        console.log(' <li>' + htmlEscape(item) + '</li>');
    }
    console.log('</ul>');

    function htmlEscape(str) {
        let result = '';
        for (let char of str) {
            if (char == '<') {
                result += '&lt;';
            } else if (char == '>') {
                result += '&gt;';
            } else if (char == '"') {
                result += '&quot;';
            } else if (char == '\'') {
                result += '&#39;';
            } else if (char == '&'){
                result += '&amp;';
            } else {
                result += char;
            }
        }
        return result;
    }
}