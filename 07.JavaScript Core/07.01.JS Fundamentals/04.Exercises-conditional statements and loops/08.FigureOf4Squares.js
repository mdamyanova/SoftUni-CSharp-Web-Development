function figure([n]){
    n = Number(n);
    let dash = '-'.repeat(n-2);
    let space = ' '.repeat(n-2);
    let char = '|';
    let plus = '+';
    
    if(n != 2){

        console.log(plus + dash + plus + dash + plus);

        for(let i = 0; i < n/2 - 2; i++){
            console.log(char + space + char + space + char);
        }

        console.log(plus + dash + plus + dash + plus);

        for(let i = 0; i < n/2 - 2; i++){
            console.log(char + space + char + space + char);
        }

        console.log(plus + dash + plus + dash + plus);
    } else{
        console.log(plus + plus +plus);
    }
}