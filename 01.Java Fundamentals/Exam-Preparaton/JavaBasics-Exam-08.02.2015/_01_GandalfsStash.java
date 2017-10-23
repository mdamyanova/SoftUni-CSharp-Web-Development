import java.util.Scanner;

public class _01_GandalfsStash {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int startMood = Integer.parseInt(sc.nextLine());
        String[] input = sc.nextLine().toLowerCase().split("[^a-zA-Z]+");
        for (String word : input) {
           switch (word){
               case "cram":
                   startMood += 2;
                   break;
               case "lembas":
                   startMood += 3;
                   break;
               case "apple":
                   startMood += 1;
                   break;
               case "melon":
                   startMood += 1;
                   break;
               case "honeycake":
                   startMood += 5;
                   break;
               case "mushrooms":
                   startMood -= 10;
                   break;
               default:
                   startMood -= 1;
           }
        }

        System.out.println(startMood);
        if(startMood < -5){
            System.out.println("Angry");
        } else if(startMood >= -5 && startMood < 0){
            System.out.println("Sad");
        } else if(startMood >= 0 && startMood < 15){
            System.out.println("Happy");
        } else if(startMood > 15){
            System.out.println("Special JavaScript mood");
        }
    }
}