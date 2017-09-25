function usernames(input) {
    let result = [];
    for(let username of input){
        let tokens = username.split('@');
        let domain = tokens[1].split('.');
        let user = tokens[0] + '.';
        domain.forEach(w => user+=w[0]);

        result.push(user)
    }
    console.log(result.join(', '))
}