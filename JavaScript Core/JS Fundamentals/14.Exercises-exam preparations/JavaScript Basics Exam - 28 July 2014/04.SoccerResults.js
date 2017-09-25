function soccerResult(input) {
    let result = [];
    for (let line of input) {
        let data = line.split(/\s*\/\s*/);
        let homeTeam = data[0];
        let awayTeamAndGoals = data[1].split(/\s*:\s*/);
        let awayTeam = awayTeamAndGoals[0];
        let goals = awayTeamAndGoals[1].split('-');
        let homeGoals = Number(goals[0]);
        let awayGoals = Number(goals[1]);
        processResult(result, homeTeam, awayTeam, homeGoals, awayGoals);
        processResult(result, awayTeam, homeTeam, awayGoals, homeGoals);
        //console.log(homeTeam + awayTeam + homeGoals + awayGoals);
    }
    result = sortObjectProperties(result);
    for(let team in result){
        result[team].matchesPlayedWith.sort();
    }
    console.log(JSON.stringify(result));

    function processResult(result, homeTeam, awayTeam, homeGoals, awayGoals) {
        if (!result[homeTeam]) {
            result[homeTeam] = {goalsScored: 0, goalsConceded: 0, matchesPlayedWith: []};
        }
        result[homeTeam].goalsScored += homeGoals;
        result[homeTeam].goalsConceded += awayGoals;
        if (result[homeTeam].matchesPlayedWith.indexOf(awayTeam) == -1) {
            result[homeTeam].matchesPlayedWith.push(awayTeam);
        }
    }

    function sortObjectProperties(obj) {
        let keysSorted = Object.keys(obj).sort();
        let sortedObj = {};
        for (let i = 0; i < keysSorted.length; i++) {
            let key = keysSorted[i];
            sortedObj[key] = obj[key];
        }
        return sortedObj;
    }
}
