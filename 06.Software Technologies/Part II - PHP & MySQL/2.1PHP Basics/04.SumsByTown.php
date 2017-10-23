<?php function calcSumsByTown(array $townsIncomes) : array
{
    $sums = []; // Empty associative array to hold {town -> sum}
    foreach ($townsIncomes as $townIncome) {
        $tokens = explode(':', $townIncome);
        $town = $tokens[0]; $income = $tokens[1];
        if (isset($sums[$town]))
            $sums[$town] += $income;
        else
            $sums[$town] = $income;
    }
    ksort($sums);
    return $sums;
}
if (isset($_GET['towns-incomes'])) {
    $townsIncomes = array_map('trim',
        explode("\n", $_GET['towns-incomes']));
    $sumsByTown = calcSumsByTown($townsIncomes);
    foreach ($sumsByTown as $town => $sum)
        echo $town . " -> " . $sum . "<br>\n";
} ?>
<form>
    <textarea rows="10" name="towns-incomes"></textarea><br>
    <input type="submit" value="Calculate">
</form>