function rectangle([n]) {
    function printStars(num) {
        let result = "";
        for(let i=0;i<num;i++){
            result+=`${"*" + " *".repeat(num-1)}\n`;
        }
        return result;
    }

    let num = Number(n);
    if(n!=NaN){
        console.log(printStars(num));
    } else {
        console.log(printStars(5));
    }
}