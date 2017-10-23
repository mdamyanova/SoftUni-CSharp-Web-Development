$(solve);

function solve(){
    let appKey = 'kid_BJXTsSi-e';
    let appSecret = '447b8e7046f048039d95610c1b039390';
    let baseUrl = `https://baas.kinvey.com/appdata/${appKey}`;
    let username = 'guest';
    let password = 'guest';
    let base64auth = btoa(`${username}:${password}`);
    let authHeaders = {
        'Authorization': `Basic ${base64auth}`,
        'Content-Type': 'application/json'
    };

    let studentKeys = ['ID', 'FirstName', 'LastName', 'FacultyNumber', 'Grade'];
    let table = $('#results');

    $(getStudents);

    function getStudents() {
        let getStudentsRequest = {
            method: 'GET',
            url: `${baseUrl}/students`,
            headers: authHeaders
        };

        $.ajax(getStudentsRequest)
            .then(displayStudents)
            .then(attachTableEvents)
            .catch(displayError)
    }

    function attachTableEvents() {
        $('#add-student').click(addStudent);
    }

    function addStudent() {
        let newStudent = getNewStudentData();
        let addStudentRequest = {
            method: 'POST',
            url: `${baseUrl}/students`,
            headers: authHeaders,
            data: JSON.stringify(newStudent)
        };

        $.ajax(addStudentRequest)
            .then(getStudents)
            .catch(displayAddStudentError);
    }

    function displayAddStudentError(err) {
        let errDiv = $('<div>').css({
            background: 'red',
            color: 'white',
            fontSize: '20px'
        })
            .text('Error: Invalid student data')
            .fadeOut(5000);

        $('body').prepend(errDiv);
    }

    function getNewStudentData() {
        let id = $('#student-id').val();
        let firstName = $('#student-first-name').val();
        let lastName = $('#student-last-name').val();
        let facultyNumber = $('#student-faculty-number').val();
        let grade = $('#student-grade').val();
        validateEntries(id, firstName, lastName, facultyNumber, grade);
        return {
            ID: Number(id),
            FirstName: firstName,
            LastName: lastName,
            FacultyNumber: facultyNumber,
            Grade: Number(grade)
        };
    }

    function validateEntries(id, firstName, lastName, facultyNumber, grade) {
        if (id === '' || !Number(id)) {
            displayAddStudentError();
            throw new Error('Error: Invalid ID ' + id);
        }

        if (firstName === '') {
            displayAddStudentError();
            throw new Error('Error: Invalid first name ' + firstName);
        }

        if (lastName === '') {
            displayAddStudentError();
            throw new Error('Error: Invalid last name ' + lastName);
        }

        if (facultyNumber === '') {
            displayAddStudentError();
            throw new Error('Error: Invalid faculty number ' + facultyNumber);
        }

        if (grade === '' || !Number(grade)) {
            displayAddStudentError();
            throw new Error('Error: Invalid grade ' + grade);
        }
    }

    function displayStudents (students) {
        table.find('tr:not(:first)').remove();
        students.sort((a, b) => a.ID - b.ID);

        for (let student of students) {
            let row = `<tr>`;
            for (let key of studentKeys) {
                row += `<td>${student[key]}</td>`;
            }
            row += '</tr>';
            table.append($(row));
        }

        appendAddStudentRow();
    }

    function appendAddStudentRow () {
        let row = `<tr>
                    <td><input type="number" name="ID" id="student-id" placeholder="ID" required></td>
                    <td><input type="text" name="first-name" id="student-first-name" placeholder="First name" required></td>
                    <td><input type="text" name="last-name" id="student-last-name" placeholder="Last name" required></td>
                    <td><input type="text" name="faculty-number" id="student-faculty-number" placeholder="Faculty number" required></td>
                    <td><input type="number" name="grade" id="student-grade" placeholder="Grade" required></td>
                    <td><input type="button" name="add" id="add-student" value="Add"></td>
                </tr>`;
        table.append($(row));
    }

    function displayError () {

    }
}