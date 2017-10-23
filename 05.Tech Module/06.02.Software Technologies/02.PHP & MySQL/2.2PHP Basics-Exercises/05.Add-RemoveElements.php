<html>
<head>

</head>
<body>
    <form>
        Delimiter: <input type="text" name="delimiter">
        Input: <textarea name="commands"></textarea>
        <input type="submit">
    </form>
</body>
</html>

<?php
    if(isset($_GET['delimiter']) && isset($_GET['commands'])){
        $lines = explode("\n" , $_GET['commands']);
        $lines = array_map('trim', $lines);
        $resultArr = [];
 
        foreach ($lines as $line){
            $lineParams = explode($_GET['delimiter'], $line);
 
            if($lineParams[0] == "add"){
                array_push($resultArr, $lineParams[1]);
            } else {
                array_splice($resultArr, intval($lineParams[1]), 1);
            }
        }
 
        foreach ($resultArr as $resultLine){
            echo $resultLine . "<br>";
        }
    }
?>