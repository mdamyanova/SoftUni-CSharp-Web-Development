import java.util.*;

public class _04_CouplesFrequency {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        List<Integer> nums = new ArrayList<>();
        String[] input = sc.nextLine().split(" ");
        for (int i = 0; i < input.length; i++) {
            nums.add(i, Integer.parseInt(input[i]));
        }

        LinkedHashMap<String, Integer> couples = new LinkedHashMap<>();
        for (int i = 0; i < nums.size() - 1; i++) {
            int firstNum = nums.get(i);
            int secondNum = nums.get(i + 1);
            String couple = Integer.toString(firstNum) + " " + Integer.toString(secondNum);

            if(!couples.containsKey(couple)){
                couples.put(couple, 1);
            } else {
                int oldValue = couples.get(couple);
                couples.put(couple, oldValue + 1);
            }
        }
        int sum = 0;
        for(Map.Entry<String, Integer> entry:couples.entrySet()){
            Integer counter = entry.getValue();
            sum += counter;
        }

        for(Map.Entry<String, Integer> entry:couples.entrySet()){
            String couple = entry.getKey();
            Integer counter = entry.getValue();
            double percentage = ((double)counter / sum) * 100;
            System.out.printf("%s -> %.2f%%", couple, percentage);
            System.out.println();

        }
    }
}