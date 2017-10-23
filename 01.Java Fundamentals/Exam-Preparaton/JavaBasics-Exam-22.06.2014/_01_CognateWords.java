import java.util.HashSet;
import java.util.Scanner;

public class _01_CognateWords {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] words = sc.nextLine().split("[^a-zA-Z]+");

        HashSet<String> cognateWords = new HashSet<>();
        for (int i = 0; i < words.length; i++) {
            for (int j = 0; j < words.length; j++) {
                for (int k = 0; k < words.length; k++) {
                    String a = words[i];
                    String b = words[j];
                    String c = words[k];
                    String ab = a + b;
                    if(i != j){
                        boolean check = (a + b).equals(c);
                        if(check) {
                            cognateWords.add(a + "|" + b + "=" + c);
                        }
                    }
                }
            }
        }
       if(!cognateWords.isEmpty()){
           for(String cognateWord:cognateWords){
               System.out.println(cognateWord);
           }
       } else {
           System.out.println("No");
       }
    }
}