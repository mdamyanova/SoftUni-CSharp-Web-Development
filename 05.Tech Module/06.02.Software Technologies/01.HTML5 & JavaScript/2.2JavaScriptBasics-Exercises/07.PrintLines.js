function printLines(arr) {
   for(let a of arr){
       if(a == "Stop"){
           break;
       }
       console.log(a);
   }
}