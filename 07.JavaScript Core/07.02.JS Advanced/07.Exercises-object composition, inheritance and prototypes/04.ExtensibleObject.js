function xtensibleObject(inputObj) {
    let extensibleObject = {
        extend: extend
    };

    return extensibleObject;

    function extend (obj) {
        let copy = Object.getPrototypeOf(extensibleObject);

        for (let attr in obj) {
            if (obj.hasOwnProperty(attr)) {
                copy[attr] = obj[attr];
                extensibleObject[attr] = obj[attr];
            }
        }

        return copy;
    }
}