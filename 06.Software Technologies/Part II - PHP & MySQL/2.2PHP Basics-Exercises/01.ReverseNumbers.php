<html>
<head>

</head>
<body>
    <form>
        Delimiter: <input type="text" name="delimiter">
        Input: <textarea name="numbers"></textarea>
        <input type="submit">
    </form>
</body>
</html>

<?php if(isset($_GET['numbers']) && isset($_GET['delimiter'])){
		$delimiter = $_GET['delimiter'];
		$lines = $_GET['numbers'];
		$arr = explode($delimiter, $lines);
		$arr = array_map('trim', $arr);

		for($i = count($arr) - 1; $i >= 0; $i--){
			echo $arr[$i] . '<br>';
		}
} ?>