<html>
<head>

</head>
<body>
<form>
    Input:
    <br>
    <textarea name="input"></textarea>
    <br>
    Delimiter:
    <br>
    <input type="text" name="delimiter">
    <br>
    <input type="submit">
</form>
</body>
</html>

<?php if(isset($_GET['delimiter']) && isset($_GET['input'])) {
    $delimiter = $_GET['delimiter'];
    $input = explode("\n", $_GET['input']);
    $keyValuePairs = [];

    for ($i = 0; $i < count($input); $i++) {
        $temp = explode($delimiter, $input[$i]);
        $temp = array_map('trim', $temp);

        if ($temp[0] != "" && $temp[1] != null) {
            if (is_numeric($temp[1])) {
            $temp[1] = doubleval($temp[1]);
        	}

        $keyValuePairs[$temp[0]] = $temp[1];
        }
    }

    $jsonobj = json_encode($keyValuePairs, JSON_UNESCAPED_SLASHES);
  
    echo $jsonobj;
} ?>