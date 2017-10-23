import java.util.*;
import java.util.HashMap;
import java.util.Scanner;

public class Problem23_PhonebookUpgrade {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] input = scan.nextLine().split(" ");
        HashMap<String, String> phonebook = new HashMap<String, String>();

        while (!input[0].equals("END")) {
            if (input[0].equals("A")) {
                String name = input[1];
                String phone = input[2];
                phonebook.put(name, phone);
            } else if (input[0].equals("S")) {
                String name = input[1];
                if (phonebook.containsKey(name)) {
                    System.out.println(name + " -> " + phonebook.get(name));
                } else {
                    System.out.println("Contact " + name + " does not exist.");
                }
            } else {
                Map<String, String> map = new TreeMap<String, String>(phonebook);
                Set set = map.entrySet();
                for (Object aSet : set) {
                    Map.Entry me = (Map.Entry) aSet;
                    System.out.print(me.getKey() + " -> ");
                    System.out.println(me.getValue());
                }
            }
            input = scan.nextLine().split(" ");
        }
    }
}