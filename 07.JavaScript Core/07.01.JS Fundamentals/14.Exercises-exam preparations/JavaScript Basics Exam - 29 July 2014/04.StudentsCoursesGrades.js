function aggregateStudentResults(input) {
    let results = { };
    for (let i = 0; i < input.length; i++) {
        let tokens = input[i].split('|');
        let student = tokens[0].trim();
        let course = tokens[1].trim();
        let grade = Number(tokens[2].trim());
        let visits = Number(tokens[3].trim());
        if (!results[course]) {
            results[course] = { grades: [], visits: [], students: [] };
        }
        results[course].grades.push(grade);
        results[course].visits.push(visits);
        if (results[course].students.indexOf(student) == -1) {
            results[course].students.push(student);
        }
    }

    let output = { };
    let courses = Object.keys(results).sort();
    for (let course in courses) {
        let courseName = courses[course];
        let courseInfo = {
            avgGrade: average(results[courseName].grades),
            avgVisits: average(results[courseName].visits),
            students: results[courseName].students.sort()
        };
        output[courseName] = courseInfo;
    }

    console.log(JSON.stringify(output));

    function average(arr) {
        let sum = 0;
        for (let i in arr) {
            sum += arr[i];
        }
        let avg = sum / arr.length;
        avg = Number(avg.toFixed(2));
        return avg;
    }
}