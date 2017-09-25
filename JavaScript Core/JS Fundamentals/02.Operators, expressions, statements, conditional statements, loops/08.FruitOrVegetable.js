function fruitOrVegetable(input) {
    switch (input[0]){
        case 'banana':
        case 'apple':
        case 'kiwi':
        case 'cherry':
        case 'lemon':
        case 'grapes':
        case 'peach':
            return "fruit";
        case 'tomato':
        case 'cucumber':
        case 'pepper':
        case 'onion':
        case 'garlic':
        case 'parsley':
            return "vegetable";
        default:
            return "unknown";
    }
}