
import java.util.*;

public class _04_ActivityTracker {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        TreeMap<Integer, TreeMap<String, Integer>> data = new TreeMap<>();
        for (int i = 0; i < n; i++) {
            String[] input = sc.nextLine().split("[/ ]");
            int month = Integer.parseInt(input[1]);
            String name = input[3];
            int distance = Integer.parseInt(input[4]);
            if(!data.containsKey(month)){
                TreeMap<String, Integer> users = new TreeMap<>();
                users.put(name, distance);
                data.put(month, users);
            } else {
                TreeMap<String, Integer> users = data.get(month);
                if(!users.containsKey(name)){
                    users.put(name, distance);
                } else {
                    int tempDistance = users.get(name);
                    tempDistance += distance;
                    users.put(name, tempDistance);
                }
                data.put(month, users);
            }

        }
        for (Iterator it = data.entrySet().iterator(); it.hasNext();) {
            Map.Entry currMonth = (Map.Entry) it.next();

            String outputLine = currMonth.getKey() + ": ";

            TreeMap users = (TreeMap) currMonth.getValue();
            for (Iterator it2 = users.entrySet().iterator(); it2.hasNext();) {
                Map.Entry user = (Map.Entry) it2.next();

                outputLine += user.getKey() + "(" + user.getValue() + "), ";
            }
            outputLine = outputLine.substring(0, outputLine.length() - 2);
            System.out.println(outputLine);
        }
    }
}