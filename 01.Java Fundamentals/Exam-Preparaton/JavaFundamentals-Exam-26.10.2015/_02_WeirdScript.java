import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _02_WeirdScript {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int keyNum = Integer.parseInt(sc.nextLine()) % 52;
        if(keyNum == 0){
            keyNum += 52;
        }
        if(keyNum < 27){
            keyNum += 'a' - 1;
        } else {
            keyNum += 'A' - 26 - 1;
        }

        String key = "" + (char)keyNum + (char)keyNum;
        String text = "";
        String line = sc.nextLine();
        while(!line.equals("End")){
            text += line;
            line = sc.nextLine();
        }

        Pattern pattern = Pattern.compile(key + "(.*?)" + key);
        Matcher matcher = pattern.matcher(text);

        while(matcher.find()){
            System.out.println(matcher.group(1));
        }
    }
}