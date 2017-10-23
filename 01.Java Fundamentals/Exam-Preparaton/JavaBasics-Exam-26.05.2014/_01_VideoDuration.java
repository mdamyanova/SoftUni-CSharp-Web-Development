import java.util.Scanner;

public class _01_VideoDuration {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        int hours = 0;
        int minutes = 0;

        while(!input.equals("End")){

            String[] split = input.split(":");
            int hoursInput = Integer.parseInt(split[0]);
            if(hoursInput > 0){
                minutes += hoursInput * 60;
            }
            int minutesInput = Integer.parseInt(split[1]);
            if(split[1].substring(0, 1).equals("0")){
                minutesInput = Integer.parseInt(split[1].substring(1));
            }
            minutes += minutesInput;
            input = sc.nextLine();
        }
        hours = minutes / 60;
        minutes = minutes % 60;
        if(minutes < 10){
            System.out.println(hours + ":0" + minutes);
        } else{
            System.out.println(hours + ":" + minutes);
        }
    }
}