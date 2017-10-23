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

<?php if(isset($_GET['input']) && isset($_GET['delimiter'])){
		$lines = explode("\n" , $_GET['input']);
        $lines = array_map('trim', $lines);
		$delimiter = $_GET['delimiter'];

		foreach ($lines as $line) {
			$pairs = explode($delimiter, $line);
			$grade = doubleval($pairs[2]);
			echo "<ul><li>Name: $pairs[0]</li><li>Age: $pairs[1]</li><li>Grade: $grade</li></ul>";
		}
	}
?>