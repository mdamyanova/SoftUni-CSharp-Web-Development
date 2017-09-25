function treasureLocator(input) {
    for(let i=0; i<input.length-1; i+=2){
        let a = Number(input[i]);
        let b = Number(input[i+1]);
        console.log(findTreasure(a, b));
    }

    function findTreasure(a, b) {
        if((a >= 1 && a <= 3) && (b >= 1 && b <= 3)){
            return 'Tuvalu';
        } else if((a >= 8 && a <= 9) && (b >= 0 && b <= 1)){
            return 'Tokelau';
        } else if((a >= 5 && a <= 7) && (b >= 3 && b <= 6)){
            return 'Samoa';
        } else if((a >= 0 && a <= 2) && (b >= 6 && b <= 8)){
            return 'Tonga';
        } else if((a >= 4 && a <= 9) && (b >= 7 && b <= 8)){
            return 'Cook';
        } else {
            return 'On the bottom of the ocean'
        }
    }
}

treasureLocator([4, 2, 1.5, 6.5, 1, 3]);