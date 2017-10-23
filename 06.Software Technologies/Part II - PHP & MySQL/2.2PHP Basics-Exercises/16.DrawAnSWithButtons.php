<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>First Steps Into PHP</title>
        <style>
            table * {
                border: 1px solid black;
                width: 50px;
                height: 50px;
            }
            div {
                width: 50px;
                height: 50px;
                border: 1px;
            }
        </style>
    </head>
    <body>
        <table>
            <tr>
                <td>
                    Red
                </td>
                <td>
                    Green
                </td>
                <td>
                    Blue
                </td>
            </tr>
            <?php for ($row = 0; $row < 9; $row++) {
                    for ($col = 0; $col < 5; $col++) {
                         if ($row == 0 || $row == 8 || $row == 4 || $col == 0 &&
                             ($row > 0 && $row < 5) || $col == 4 && $row > 4)
                                 {
                                    $color = "style='background-color:blue'";
                                    $button = "<button $color>1</button>";
                                } else {
                                    $button = "<button>0</button>";
                                }
                                echo $button;
                         }
                            echo "<br/>";
                    } ?>
        </table>
    </body>
</html>