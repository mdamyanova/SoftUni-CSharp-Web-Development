function triangle([n]){
    let num = Number(n);
    let result = "";
    for(let i=1;i<=num;i++){
        result+="*".repeat(i)+"\n";
    }
    for(let i=num-1;i>=1;i--){
        result+="*".repeat(i)+"\n";
    }
    console.log(result)
}