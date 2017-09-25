function radioCrystals(input) {
    let cut = x => x/4;
    let lap = x => x*0.8;
    let grind = x => x-20;
    let etch = x => x-2;
    let xRay = x => ++x;
    let transportAndWashing = x => Math.floor(x);

    input = input.map(Number);
    let desiredMicrons = input[0];
    let crystals = input.splice(1, input.length-1);

    for(let i=0;i<crystals.length;i++){
        let crystal = crystals[i];

        console.log(`Processing chunk ${crystal} microns`);

        crystal = performOperation(cut, 'Cut', crystal, desiredMicrons);
        crystal = performOperation(lap, 'Lap', crystal, desiredMicrons);
        crystal = performOperation(grind, 'Grind', crystal, desiredMicrons);
        crystal = performOperation(etch, 'Etch', crystal, desiredMicrons);

        if(crystal < desiredMicrons){
            crystal = xRay(crystal);
            console.log('X-ray x1');
        }

        console.log(`Finished crystal ${crystal} microns`)
    }

    function performOperation(op, opName, currThickness, desiredThickness) {
        let count = 0;
        while (true){
            let newThickness = op(currThickness);
            if(Math.floor(newThickness) + 1 == desiredThickness){
                currThickness = newThickness;
                count++;
                break;
            }

            if(newThickness < desiredThickness){
                break;
            }

            currThickness = newThickness;
            count++;
        }

        if(count > 0){
            console.log(`${opName} x${count}`);
            console.log('Transporting and washing');
            currThickness = transportAndWashing(currThickness);
        }
        return currThickness;
    }
}