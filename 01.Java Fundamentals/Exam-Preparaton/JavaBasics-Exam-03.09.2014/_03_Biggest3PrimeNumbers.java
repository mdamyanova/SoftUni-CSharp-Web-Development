import java.util.Collections;
import java.util.Scanner;
import java.util.TreeSet;

public class _03_Biggest3PrimeNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine().trim();
        String[] inputSplit = input.split("[( )]+");

        TreeSet<Integer> numberSet = new TreeSet<>(Collections.reverseOrder());
        for (int i = 0; i < inputSplit.length; i++) {
            if (!inputSplit[i].equals("")) {
                int number = Integer.parseInt(inputSplit[i]);
                numberSet.add(number);
            }
        }

        int primesCount = 0;
        int primesSum = 0;
        for(Integer posiblePrime : numberSet){
            if(posiblePrime <= 1 || primesCount == 3){
                break;
            }
            boolean isPrime = true;
            for (int i = 2; i < posiblePrime; i++) {
                if(posiblePrime % i == 0){
                    isPrime = false;
                }
            }
            if(isPrime){
                primesSum += posiblePrime;
                primesCount++;
            }
        }
        if(primesCount == 3){
            System.out.println(primesSum);
        } else {
            System.out.println("No");
        }
    }
}