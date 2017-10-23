<html>
<head>

</head>
<body>
<form>
    Delimiter: <input type="text" name="delimiter">
    Array-size: <input type="text" name="array-size">
    Input: <textarea name="key-value-pairs"></textarea>
    <input type="submit">
</form>
</body>
</html>
<?php if(isset($_GET['delimiter']) && isset($_GET['array-size']) && isset($_GET['key-value-pairs'])){
    $delimiter = $_GET['delimiter'];
    $lines = explode("\n", $_GET['key-value-pairs']);
    $lines = array_map('trim', $lines);

    $arr = [];

    for($i = 0; $i < $_GET['array-size']; $i++){
        $arr[$i] = 0;
    }

    foreach ($lines as $line) {
        $pair = explode($delimiter, $line);
        $arr[$pair[0]] = $pair[1];
    }

    foreach ($arr as $line) {
        echo($line . '<br>');
    }
} ?>