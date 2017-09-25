function systemComponents(input) {
    let system = new Map;
    for(let line of input){
        line = line.split(' | ');
        let systemName = line[0];
        let componentName = line[1];
        let subcomponentName = line[2];

        // check if we have the system as key
        if(!system.has(systemName)){
            system.set(systemName, new Map);
        }

        // check if we have the componentName as key of system values of key systemName
        if(!system.get(systemName).has(componentName)){
            system.get(systemName).set(componentName, [])
        }

        system.get(systemName).get(componentName).push(subcomponentName);
    }

    // sort by amount of components in descending order as first criteria,
    // then by alphabetical order as second criteria
    function sortSystemComparator(sysA, sysB, catalogue) {
        let aComponents = catalogue.get(sysA).size;
        let bComponents = catalogue.get(sysB).size;
        if (aComponents > bComponents) return -1;
        if (aComponents < bComponents) return 1;

        return sysA.toLowerCase().localeCompare(sysB.toLocaleLowerCase());
    }

    let result = [...system.keys()].sort((a, b) => sortSystemComparator(a, b, system));
    for (let s of result) {
        console.log(s);
        let components = [...system.get(s).keys()].sort((s1, s2) => system.get(s).get(s2).length - system.get(s).get(s1).length);
        for (let component of components) {
            console.log(`|||${component}`);
            for (let subComponent of system.get(s).get(component)) {
                console.log(`||||||${subComponent}`);
            }
        }
    }
}
