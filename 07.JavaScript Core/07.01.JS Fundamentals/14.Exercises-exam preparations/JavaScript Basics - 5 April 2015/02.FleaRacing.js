function fleaRacing(input) {
    var maxJumps = Number(input[0]),
        trackLength = Number(input[1]),
        flees = [],
        tribunes = new Array(trackLength+1).join('#'),
        track = [],
        winner,
        fleeCount = 0;


    for (var i = 2; i < input.length; i++) {
        var fleeInfo = input[i].split(/[, ]+/g);
        flees.push({
            initial: fleeInfo[0].substr(0,1).toUpperCase(),
            name: fleeInfo[0],
            jumpDistance: Number(fleeInfo[1]),
            index: 0,
            trackIndex: fleeCount
        });

        var fleeTrack = Array.apply(null, new Array(trackLength)).map(function() { return '.'; });
        fleeTrack[0] = fleeInfo[0].substr(0,1).toUpperCase();
        track.push(fleeTrack);
        ++fleeCount;
    }

    for (i = 0; i < maxJumps; i++) {
        var hasFinished = false;
        flees.every(function(flee) {
            if(flee.index + flee.jumpDistance >= trackLength - 1) {
                hasFinished = flee;
                track[flee.trackIndex][flee.index] = '.';
                track[flee.trackIndex][track[flee.trackIndex].length-1] = flee.initial;
                return false;
            } else {
                track[flee.trackIndex][flee.index] = '.';
                track[flee.trackIndex][flee.index + flee.jumpDistance] = flee.initial;
                flee.index += flee.jumpDistance;
                return true;
            }
        });

        if(hasFinished) {
            winner = hasFinished;
            break;
        }
    }

    console.log(tribunes);
    console.log(tribunes);
    track.forEach(function(fleeTrack) {
        console.log(fleeTrack.join(''));
    });
    console.log(tribunes);
    console.log(tribunes);
    if(!winner) {
        var maxPos = 0;
        flees.forEach(function(flee) {
            if(flee.index >= maxPos) {
                maxPos = flee.index;
                winner = flee;
            }
        })
    }
    console.log('Winner: ' + winner.name);
}