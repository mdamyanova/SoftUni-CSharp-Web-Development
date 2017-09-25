function calculateCoins(input){

    var coins = 0,
        bronzeCoins = 0,
        silverCoins = 0,
        goldCoins = 0;


    for(var i= 0; i<input.length; i++){
        var tokens = input[i].split(' ');
        var type = tokens[0].toLowerCase();
        var value = tokens[1];
        if(value > 0 && isInt(value) && type === 'coin' ){
            coins += parseInt(value);
        }
    }

    goldCoins += Math.floor(coins/100);
    coins = coins - goldCoins*100;
    silverCoins += Math.floor(coins/10);
    bronzeCoins += coins - silverCoins*10;

    console.log('gold : ' + goldCoins);
    console.log('silver : ' + silverCoins);
    console.log('bronze : ' + bronzeCoins);


    function isInt(n){
        return  n % 1 === 0;
    }
}