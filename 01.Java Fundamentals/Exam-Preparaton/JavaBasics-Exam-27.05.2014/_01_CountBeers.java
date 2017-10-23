import java.util.Scanner;

public class _01_CountBeers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        int stacks = 0;
        int beers = 0;
        while(!input.equals("End")){
            String[] splitted = input.split(" ");
            int count = Integer.parseInt(splitted[0]);
            String measure = splitted[1];
            if(measure.equals("stacks")){
                beers += count * 20;
            } else {
                beers += count;
            }
            input = sc.nextLine();
        }
        stacks = beers / 20;
        beers = beers % 20;
        System.out.printf("%d stacks + %d beers", stacks, beers);
    }
}