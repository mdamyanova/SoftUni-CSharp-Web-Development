function distanceIn3D([aX, aY, aZ, bX, bY, bZ]) {
    let distance = Math.pow((bX - aX), 2) +
        Math.pow((bY - aY), 2) +
        Math.pow((bZ - aZ), 2);
    return Math.sqrt(distance);
}