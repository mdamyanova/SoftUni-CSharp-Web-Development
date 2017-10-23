<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>First Steps Into PHP</title>
    </head>
    <body>
        <form>
            N: <input type="text" name="num" />
            <input type="submit" />
        </form>
        <?php if(isset($_GET['num'])){
            $num = intval($_GET['num']);
            function isPrime($num)
            {
                if($num == 1) {
                    return false;
                }
                if($num == 2) {
                    return true;
                }
                if($num % 2 == 0) {
                    return false;
                }

                for($i = 3; $i <= ceil(sqrt($num)); $i = $i + 2) {
                    if($num % $i == 0) {
                        return false;
                    }
                }
                return true;
            }
            for($i = $num; $i >= 1; $i--){
                if(isPrime($i)){
                    echo "$i\n";
                }
            }
        } ?>
    </body>
</html>