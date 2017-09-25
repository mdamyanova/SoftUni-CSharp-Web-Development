function distanceOverTime(input) {
    let dist1 = ((input[0] * 1000) / 3600)* input[2];
    let dist2 = ((input[1] * 1000) / 3600) * input[2];
    return Math.abs(dist1 - dist2);
}