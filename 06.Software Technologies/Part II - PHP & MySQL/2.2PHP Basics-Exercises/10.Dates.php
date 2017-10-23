<html>
<head>

</head>
<body>
<form>
    Start Date:
    <br>
    <input type="text" name="date">

    <br>
    Output Format:
    <br>
    <input type="text" name="format">
    <br>
    Commands:
    <br>
    <textarea name="commands"></textarea>
    <br>
    <input type="submit">
</form>
</body>
</html>


<?php if (isset($_GET['commands']) && isset($_GET['format']) && isset($_GET['date'])) {
            $commands = $_GET['commands'];
            $lines = explode("\r\n", $commands);
            $dateStr = $_GET['date'];
            $date = DateTime::createFromFormat('d/m/Y', $dateStr);
            $format = $_GET['format'];

            foreach ($lines as $line) {
                $temp = explode(" ", $line);
                $cmd = $temp[0];
                $val = $temp[1];
                if ($cmd == 'add') {
                    $date->add(new DateInterval("P" . "$val" . "D"));
                } else if ($cmd == 'subtract') {
                    $date->sub(new DateInterval("P" . "$val" . "D"));
                }
            }

            echo $date->format($format);
     } ?>