import java.util.Random;
import java.util.Scanner;

public class Problem25_AdvertisementMessage {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] phrases =
                {
                        "Excellent product.", "Such a great product.", "I always use that product.",
                        "Best product of its category.", "Exceptional product.",
                        "I can’t live without this product."
                };

        String[] events =
                {
                        "Now I feel good.", "I have succeeded with this product.",
                        "Makes miracles. I am happy of the results!",
                        "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.",
                        "I feel great!"
                };

        String[] author = {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};

        String[] cities = {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

        int n = Integer.parseInt(scan.nextLine());

        Random phraseIndex = new Random();
        Random eventIndex = new Random();
        Random authorIndex = new Random();
        Random townIndex = new Random();

        for (int i = 0; i < n; i++) {
            System.out.println(phrases[phraseIndex.nextInt(phrases.length)] + " " + events[eventIndex.nextInt(events.length)]
                    + " " + author[authorIndex.nextInt(author.length)] + " - " + cities[townIndex.nextInt(cities.length)]);
        }
    }
}