function sortArray(arr) {
    return arr.sort().sort((a,b) => a.length - b.length).join('\n');
}

console.log(sortArray(['alpha', 'beta', 'gamma']));