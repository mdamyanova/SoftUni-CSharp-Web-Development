function emailValidation([email]) {
    let pattern = /^[A-Za-z\d]+@[a-z]+\.[a-z]+$/g;
    let result = pattern.test(email);
    if (result) {
        console.log("Valid");
    } else {
        console.log("Invalid");
    }
}