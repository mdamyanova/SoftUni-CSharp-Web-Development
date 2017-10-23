<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        div {
            display: inline-block;
            margin: 5px;
            width: 20px;
            height: 20px;
        }
    </style>
</head>
<body>
<?php
for ($i = 0; $i<5; $i++){
    $rgbColor = $i*51;
    for ($y= 0; $y<10; $y++){
        echo "<div style=\"background-color: rgb($rgbColor, $rgbColor, $rgbColor);\"></div>";
        $rgbColor+=5;
    }
    echo "<br>";
}
?>
</body>
</html>