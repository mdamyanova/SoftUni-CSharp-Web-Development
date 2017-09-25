function printPricesTrendsTable(input) {
    let prices = input.map(Number);
    console.log("<table>");
    console.log("<td><th>Price</th><th>Trend</th></td>");
    let prevPrice = undefined;
    for (let i = 0; i < prices.length; i++) {
        var price = prices[i];
        var priceStr = price.toFixed(2);
        if (prevPrice == undefined || priceStr == prevPrice) {
            var trend = "fixed.png";
        } else if (price < prevPrice) {
            var trend = "down.png";
        } else {
            var trend = "up.png";
        }
        console.log("<td><td>" + priceStr + "</td><td><img src=\"" + trend + "\"/></td></td>");
        prevPrice = priceStr;
    }
    console.log("</table>");
}