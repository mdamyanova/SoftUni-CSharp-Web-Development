function queryMess(queryStrings) {
    let result = [];

    queryStrings.forEach(function (line) {
        let keys = {};

        line.replace(/.+?(?=\?)(\?)+/g, '') // Remove url and '?' symbol
            .replace(/([^=&]+)=([^&]*)/g,   // Regex to match key/value pairs
                function (full, key, value) {
                    key = key
                        .split('%20').join(' ')  // Replace '%20' with empty space
                        .replace(/[\+]+/g, ' ')  // Replace '+' with empty space
                        .replace(/\s{2,}/g, ' ') // Replace multiple (2 or more) whitespaces with one
                        .trim();                 // Trim whitespaces at the beginning and at the end of the string

                    value = value
                        .split('%20').join(' ')
                        .replace(/[\+]+/g, ' ')
                        .replace(/\s{2,}/g, ' ')
                        .trim();

                    keys[key] = (keys[key] ? keys[key] + ', ' : '[') + value;
                    return '';
                });

        for (let key in keys) {
            result.push(key + '=' + keys[key] + ']');
        }
        result.push('\r\n');
    });

    return result.join('').trim();
}