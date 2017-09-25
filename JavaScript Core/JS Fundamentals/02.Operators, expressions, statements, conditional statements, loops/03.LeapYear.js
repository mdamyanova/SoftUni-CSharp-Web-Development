function leapYear(input) {
    return ((input[0] % 4 == 0) && (input[0] % 100 != 0)) || (input[0] % 400 == 0) ? "yes" : "no"
}