import java.util.*;

public class _01_DozenEggs {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int dozens = 0;
        int eggs = 0;

        for (int i = 0; i < 7; i++) {
            String[] input = sc.nextLine().split(" ");
            int currEggs = 0;
            if(input[1].equals("dozens")){
               currEggs = Integer.parseInt(input[0]) * 12;
            } else {
                 currEggs = Integer.parseInt(input[0]);
            }
            eggs += currEggs;
        }
        dozens = eggs / 12;
        eggs = eggs % 12;

        System.out.println(dozens + " dozens + " + eggs + " eggs");

    }
}