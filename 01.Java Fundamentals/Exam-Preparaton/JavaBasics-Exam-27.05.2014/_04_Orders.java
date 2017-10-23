
import java.util.*;

public class _04_Orders {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());
        LinkedHashMap<String, TreeMap<String, Integer>> orders = new LinkedHashMap<>();

        for (int i = 0; i < n; i++) {
            String[] input = sc.nextLine().split(" ");
            String customer = input[0];
            Integer amount = Integer.parseInt(input[1]);
            String product = input[2];

            if(!orders.containsKey(product)){
                orders.put(product, new TreeMap<>());
            }
            TreeMap<String, Integer> amounts = orders.get(product);
            int oldAmount = 0;
            if(amounts.containsKey(customer)){
                oldAmount = amounts.get(customer);
            }
            amounts.put(customer, oldAmount + amount);
        }

        for(String product:orders.keySet()){
            System.out.print(product + ": ");
            TreeMap<String, Integer> amounts = orders.get(product);
            boolean first = true;
            for(Map.Entry<String, Integer> pair : amounts.entrySet()){
                if(!first){
                    System.out.print(", ");
                }
                first = false;
                String customer = pair.getKey();
                int amount = pair.getValue();
                System.out.print(customer + " " + amount);
            }
            System.out.println();
        }
    }
}