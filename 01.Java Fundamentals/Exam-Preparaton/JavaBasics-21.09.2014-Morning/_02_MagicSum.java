import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class _02_MagicSum {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int D = Integer.parseInt(sc.nextLine());
        List<Integer> numbers = new ArrayList<>();
        String input = sc.nextLine();
        while(!input.equals("End")){
            numbers.add(Integer.parseInt(input));
            input = sc.nextLine();
        }

        boolean isFound = false;
        int biggestA = Integer.MIN_VALUE;
        int biggestB = Integer.MIN_VALUE;
        int biggestC = Integer.MIN_VALUE;
        int biggestSum = Integer.MIN_VALUE;
        for (int i = 0; i < numbers.size(); i++) {
            for (int j = i + 1; j < numbers.size(); j++) {
                for (int k = j + 1; k < numbers.size(); k++) {
                    int a = numbers.get(i);
                    int b = numbers.get(j);
                    int c = numbers.get(k);
                    if((a + b + c) % D == 0){
                        if(biggestSum < a + b + c){
                            isFound = true;
                            biggestSum = a + b + c;
                            biggestA = a;
                            biggestB = b;
                            biggestC = c;
                        }
                    }
                }
            }
        }
        if(!isFound){
            System.out.println("No");
        } else {
            System.out.println("(" + biggestA + " + " + biggestB + " + " + biggestC + ")" +
            " % " + D + " = 0");
        }
    }
}