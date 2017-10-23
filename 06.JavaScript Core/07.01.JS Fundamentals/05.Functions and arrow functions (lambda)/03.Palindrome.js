function palindrome([word]) {
    function checkPalindrom(str) {
        return str == str.split('').reverse().join('');
    }
    return checkPalindrom(word)
}