function storingObjects(arr) {
    let objects = {};
    for(let i = 0; i < arr.length; i++){
        let line = arr[i].split(' -> ');
        let name = line[0];
        let age = line[1];
        let grade = line[2];
        objects[i] = {Name: name, Age: age, Grade: grade};
    }
    for(let i = 0; i < arr.length; i++){

       console.log(`Name: ${objects[i].Name}\nAge: ${objects[i].Age}\nGrade: ${objects[i].Grade}`);
   }
}