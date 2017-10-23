import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class _04_Weightlifting {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        TreeMap<String, TreeMap<String, Long>> data = new TreeMap<>();
        for (int i = 0; i < n; i++) {
            String[] line = sc.nextLine().split(" ");
            String name = line[0];
            String exercise = line[1];
            long weight = Integer.parseInt(line[2]);

            if(!data.containsKey(name)){
                data.put(name, new TreeMap<>());
                data.get(name).put(exercise, weight);
            } else {
               if(!data.get(name).containsKey(exercise)) {
                   data.get(name).put(exercise, weight);
               } else {
                   long prevWeight = data.get(name).get(exercise);
                   data.get(name).put(exercise, weight + prevWeight);
               }
            }
        }

        for(Map.Entry<String, TreeMap<String, Long>> pair : data.entrySet()){
            System.out.print(pair.getKey() + " : ");

            boolean isFirst = true;
            for (Map.Entry<String, Long> exercises : pair.getValue().entrySet()){
                if(isFirst){
                    System.out.print(exercises.getKey() + " - " + exercises.getValue() + " kg");
                    isFirst = false;
                } else {
                    System.out.print(", " + exercises.getKey() + " - " + exercises.getValue() + " kg");
                }
            }
            System.out.println();
        }
    }
}