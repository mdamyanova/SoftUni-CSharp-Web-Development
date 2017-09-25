function dnaHelix([n]) {
    n = Number(n);
    let text = 'ATCGTTAGGG';
    let indexLetter = 0;

    for(let i=0;i<n;i++){
        let letterA = text[indexLetter++ % text.length];
        let letterB = text[indexLetter++ % text.length];

        switch(i%4){
            case 0:
                console.log(`**${letterA}${letterB}**`);
                break;
            case 1:
                console.log(`*${letterA}--${letterB}*`);
                break;
            case 2:
                console.log(`${letterA}----${letterB}`);
                break;
            case 3:
                console.log(`*${letterA}--${letterB}*`);
                break;
        }
    }
}