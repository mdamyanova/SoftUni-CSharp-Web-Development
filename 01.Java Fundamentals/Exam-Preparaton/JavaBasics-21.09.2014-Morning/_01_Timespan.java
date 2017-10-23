import java.util.Scanner;

public class _01_Timespan {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] start = sc.nextLine().split(":");
        String[] end = sc.nextLine().split(":");
        long startHour = Long.parseLong(start[0]);
        long startMinutes = Long.parseLong(start[1]);
        long startSeconds = Long.parseLong(start[2]);
        long endHour = Long.parseLong(end[0]);
        long endMinutes = Long.parseLong(end[1]);
        long endSeconds = Long.parseLong(end[2]);

        long startTimeInSeconds = (startHour * 3600) + (startMinutes * 60) + startSeconds;
        long endTimeInSeconds = (endHour * 3600) + (endMinutes * 60) + endSeconds;
        long difference = startTimeInSeconds - endTimeInSeconds;

        int hours = (int)(difference / 3600);
        int minutes = (int)(difference % 3600 / 60);
        int seconds = (int)(difference % 60);

        System.out.printf("%d:%s:%s",
                hours,
                minutes < 10 ? "0" + minutes : "" + minutes,
                seconds < 10 ? "0" + seconds : "" + seconds);
    }
}