<html>
<head>

</head>
<body>
<form>
    Delimiter: <input type="text" name="delimiter">
    Input: <textarea name="key-value-pairs"></textarea>
    Target Key: <input type="text" name="target-key">
    <input type="submit">
</form>
</body>
</html>
<?php if(isset($_GET['delimiter']) && isset($_GET['key-value-pairs']) && isset($_GET['target-key'])){
    $lines = $lines = explode("\n" , $_GET['key-value-pairs']);
    $lines = array_map('trim', $lines);
    $delimiter = $_GET['delimiter'];
    $targetKey = $_GET['target-key'];

    $resultArr = [];

    foreach ($lines as $line) {
        $pair = explode($delimiter, $line);
        if(!array_key_exists($pair[0], $resultArr)){
            $resultArr[$pair[0]] = [];
        }

        $resultArr[$pair[0]][] = $pair[1];
    }

    if (array_key_exists($targetKey, $resultArr))
    {
        echo implode("<br>", $resultArr[$targetKey]);
    } else {
        echo "None";
    }
} ?>