import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Pattern;

public class Problem21_ChangeToUppercase {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();
        List<String> result = new ArrayList<>();
        Pattern pattern = Pattern.compile("(<upcase>)(.*?)(</upcase>)");
        java.util.regex.Matcher match = pattern.matcher(input);

        while(match.find()){
            result.add(match.group(2));
            for (String word : result) {
                input = input.replaceAll("<upcase>" + word + "</upcase>", match.group(2).toUpperCase());
            }
        }
        System.out.println(input);
    }
}