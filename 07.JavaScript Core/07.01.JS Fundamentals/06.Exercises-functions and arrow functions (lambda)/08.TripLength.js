function tripLength([x1, y1, x2, y2, x3, y3]) {
    [x1, y1, x2, y2, x3, y3] = [x1, y1, x2, y2, x3, y3].map(Number);

    let p1p2 = calcDistance(x1, y1, x2, y2);
    let p1p3 = calcDistance(x1, y1, x3, y3);
    let p2p3 = calcDistance(x2, y2, x3, y3);

    let result = '';
    let length = 0;
    if(p1p2 <= p1p3 && p1p2 <= p2p3){
        if(p1p3 <= p2p3){
            return `1->2->3: ${p1p2+p1p3}`
        } else {
            return `1->2->3: ${p1p2+p2p3}`
        }
    } else if(p1p3 <= p1p2 && p1p3 <= p2p3){
        if(p1p2 <= p2p3){
            return `2->1->3: ${p1p2+p1p3}`
        } else {
            return `1->3->2: ${p1p3+p2p3}`
        }
    } else {
        if(p1p2 <= p1p3){
            return `1->2->3: ${p1p2+p2p3}`
        } else {
            return `1->3->2: ${p1p3+p2p3}`
        }
    }

    function calcDistance(x1, y1, x2, y2) {
        return Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
    }
}