import java.util.Scanner;

public class _01_TinySporebat {
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        int glowcaps = 0;
        int healthPoints = 5800;
        char specialLetter = 'L';

        while(!input.equals("Sporeggar")){
            char[] chars = input.toCharArray();
            for (int i = 0; i < chars.length - 1; i++) {
                if(chars[i] != specialLetter){
                    healthPoints -= chars[i];
                    if(healthPoints <= 0){
                        System.out.println("Died. Glowcaps: " + glowcaps);
                        return;

                    }
                } else {
                    healthPoints += 200;
                }
            }
            String last = "" + chars[chars.length - 1];
            glowcaps += Integer.parseInt(last);


            input = sc.nextLine();
        }

        System.out.println("Health left: " + healthPoints);
        if(glowcaps >= 30){
            int left = glowcaps - 30;
            System.out.println("Bought the sporebat. Glowcaps left: " + left);
        } else {
            int needed = 30 - glowcaps;
            System.out.println("Safe in Sporeggar, but another " + needed + " Glowcaps needed.");
        }
    }
}