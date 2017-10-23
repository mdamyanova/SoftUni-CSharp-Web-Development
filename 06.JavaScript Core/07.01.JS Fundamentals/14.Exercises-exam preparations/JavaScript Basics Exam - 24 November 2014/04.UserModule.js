function userModule(arr) {
    function getUsers() {
        var users = [];
        var userObjs = arr.slice(1);
        userObjs.forEach(function (str, index) {
            users.push(JSON.parse(str));
        });

        return users;
    }

    var sortConditions = arr[0].split('^');
    var users = getUsers();
    var students = [];
    var trainers = [];
    users.forEach(function (student) {
        if (student.role == "student") {
            students.push(student);
        } else {
            trainers.push(student);
        }
    });

    if (sortConditions[0] == "name") {
        students = students.sort(function (s1, s2) {
            if (s1.firstname == s2.firstname) {
                return s1.lastname.localeCompare(s2.lastname);
            }
            return s1.firstname.localeCompare(s2.firstname);
        });
    } else {
        students = students.sort(function (s1, s2) {
            if (s1.level == s2.level) {
                return s1.id - s2.id;
            }
            return s1.level - s2.level;
        });
    }
    trainers.sort(function (t1, t2) {
        var t1Courses = t1.courses.length;
        var t2Courses = t2.courses.length;
        if (t1Courses == t2Courses) {
            return t1.lecturesPerDay - t2.lecturesPerDay;
        }
        return t1Courses - t2Courses;
    });

    var resultStudents = [];
    students.forEach(function (el) {
        var student = {
            id: el.id,
            firstname: el.firstname,
            lastname: el.lastname,
            averageGrade: avg(el.grades).toFixed(2),
            certificate: el.certificate
        };
        resultStudents.push(student);
    });
    var resultTrainers = [];
    trainers.forEach(function (el) {
        var trainer = {
            id: el.id,
            firstname: el.firstname,
            lastname: el.lastname,
            courses: el.courses,
            lecturesPerDay: el.lecturesPerDay
        };
        resultTrainers.push(trainer);
    });
    function avg(arr) {
        var sum = 0;
        arr.forEach(function (el) {
            sum += parseFloat(el);
        });

        return sum / arr.length;
    }
}
userModule([
    'level^courses',
    '{"id":0,"firstname":"Hristiqn","lastname":"Petrov","town":"Sofia","role":"student","grades":["4.06","5.17"],"level":5,"certificate":false}',
    '{"id":1,"firstname":"Angel","lastname":"Petrov","town":"Sofia","role":"trainer","courses":["Java","JS OOP"],"lecturesPerDay":6}',
    '{"id":2,"firstname":"Gergana","lastname":"Nakov","town":"Sliven","role":"trainer","courses":["Java","JS OOP","SDA"],"lecturesPerDay":5}',
    '{"id":3,"firstname":"Angel","lastname":"Nakova","town":"Burgas","role":"trainer","courses":["Database","JS OOP","JS","C#","iOS","HTML/CSS"],"lecturesPerDay":6}',
    '{"id":4,"firstname":"Petq","lastname":"Nakova","town":"Petrich","role":"student","grades":["5.14"],"level":4,"certificate":true}',
    '{"id":5,"firstname":"Julieta","lastname":"Petrov","town":"Svishtov","role":"trainer","courses":["iOS","OOP","JS","C#","Java"],"lecturesPerDay":6}',
    '{"id":6,"firstname":"Ivan","lastname":"Ivanov","town":"Stara Zagora","role":"student","grades":["5.28","2.15","4.25","4.95"],"level":2,"certificate":true}',
    '{"id":7,"firstname":"Gergana","lastname":"Daskalov","town":"Sofia","role":"trainer","courses":["PHP","ASP.NET","SDA"],"lecturesPerDay":5}',
    '{"id":8,"firstname":"Qvor","lastname":"Dimitrov","town":"Sevlievo","role":"student","grades":["4.30","3.14","4.09","4.08","2.25"],"level":5,"certificate":true}',
    '{"id":9,"firstname":"Petq","lastname":"Nakov","town":"Gabrovo","role":"trainer","courses":["JS Apps","Java","JS","iOS","SDA","HTML/CSS"],"lecturesPerDay":9}',
    '{"id":10,"firstname":"Bobi","lastname":"Nakov","town":"Gabrovo","role":"student","grades":["3.80"],"level":1,"certificate":false}'
]);