function triangleOfDollars(input) {
    let n = Number(input);
    let str = '';
    for(let i=1;i<=n;i++){
        str += '$'.repeat(i);
        str += '\n';
    }
    console.log(str);
}