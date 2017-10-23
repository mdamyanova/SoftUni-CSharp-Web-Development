import java.util.*;
import java.util.regex.Matcher;

public class Problem16_BombNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        List<Integer> numbers = new ArrayList<Integer>();
        for(int i = 0; i < input.length; i++){
            numbers.add(Integer.parseInt(input[i]));
        }

        String[] tokens = scanner.nextLine().split(" ");
        int bombNumber = Integer.parseInt(tokens[0]);
        int bombRange = Integer.parseInt(tokens[1]);

        for(int i = 0; i < numbers.size(); i++){
            if(numbers.get(i) == bombNumber){
                numbers.set(i, 0);
                for(int j = 1; j <= bombRange; j++){
                    if(i + j >= numbers.size()){
                        break;
                    } else {
                        numbers.set(i + j, 0);
                    }
                }
                for(int k = 1; k <= bombRange; k++){
                    if(i - k < 0){
                        break;
                    } else {
                        numbers.set(i - k, 0);
                    }
                }
            }
        }

        long sum = 0;
        for(int i = 0; i < numbers.size(); i++){
            sum += numbers.get(i);
        }
        System.out.println(sum);
    }
}