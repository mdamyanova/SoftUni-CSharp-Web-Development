import java.util.Scanner;

public class _01_Enigma {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int lines = Integer.parseInt(sc.nextLine());
        int length = 0;
        for (int i = 0; i < lines; i++) {
            String input = sc.nextLine();
            length = calculateLength(input);

            char[] sequence = input.toCharArray();
            for (int j = 0; j < sequence.length; j++) {
                if(!Character.isWhitespace(sequence[j]) &&
                        !Character.isDigit(sequence[j])){
                    sequence[j] = (char)(sequence[j] + length);
                }
            }
            System.out.println(new String(sequence));
        }
    }
    private static int calculateLength(String input) {
        int halfLength = 0;
        for (int i = 0; i < input.length(); i++) {
            char currChar = input.charAt(i);
            if(!Character.isDigit(currChar) &&
                    !Character.isWhitespace(currChar)){
                halfLength++;
            }
        }
        return halfLength / 2;
    }
}