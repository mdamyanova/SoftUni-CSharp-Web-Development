function buildTable([start, end]) {
    let html = '<table>\n<tr><th>Num</th><th>Square</th><th>Fib</th></tr>\n';
    for (let num = Number(start); num <= Number(end); num++) {
        html += `<tr><td>${num}</td><td>${num * num}</td><td>${isFib(num)}</td></tr>\n`;
    }
    html += '</table>';

    return html;

    function isFib(num) {
        var prev = 0;
        var curr = 1;
        while (prev <= num) {
            if (prev == num) {
                return 'yes';
            }
            curr = prev + curr;
            prev = curr - prev;
        }
        return 'no';
    }
}

console.log(buildTable([55, 56]));