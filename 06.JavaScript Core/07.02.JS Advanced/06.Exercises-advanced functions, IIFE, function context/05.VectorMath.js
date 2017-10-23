(function result () {
    let vectorManager =  {
        add: function (vector1, vector2) {
            let resultVector = [];
            resultVector.push(vector1[0] + vector2[0]);
            resultVector.push(vector1[1] + vector2[1]);
            return resultVector;
        },
        multiply: function (vector, scalar) {
            let resultVector = [];
            resultVector.push(vector[0] * scalar);
            resultVector.push(vector[1] * scalar);
            return resultVector;
        },
        length: function (vector) {
            let xPow = vector[0] * vector[0];
            let yPow = vector[1] * vector[1];
            let result = Math.sqrt(xPow + yPow);
            return result;
        },
        dot: function (vector1, vector2) {
            let result = (vector1[0] * vector2[0]) + (vector1[1] * vector2[1]);
            return result;
        },
        cross: function  (vector1, vector2) {
            let result = (vector1[0] * vector2[1]) - (vector1[1] * vector2[0]);
            return result;
        }
    };

    return vectorManager;
})();