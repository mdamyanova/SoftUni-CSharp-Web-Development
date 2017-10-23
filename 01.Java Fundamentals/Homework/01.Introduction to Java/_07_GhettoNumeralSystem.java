// Write a program that converts the decimal number system to the ghetto numeral system.
// In the ghetto, numbers are represented as following:
//   0 – Gee
//   1 – Bro
//   2 – Zuz
//   3 – Ma
//   4 – Duh
//   5  - Yo
//   6 – Dis
//   7 – Hood
//   8 – Jam
//   9 – Mack

import java.util.Scanner;

public class _07_GhettoNumeralSystem {
    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        String numbers = input.nextLine();
        String ghetto = "";
        getGhettoName(numbers, ghetto);
    }

    private static void getGhettoName(String numbers, String ghetto) {
        for (int i = 0; i < numbers.length(); i++) {
            switch (numbers.charAt(i)) {
                case '0':
                    ghetto += "Gee";
                    break;
                case '1':
                    ghetto += "Bro";
                    break;
                case '2':
                    ghetto += "Zuz";
                    break;
                case '3':
                    ghetto += "Ma";
                    break;
                case '4':
                    ghetto += "Duh";
                    break;
                case '5':
                    ghetto += "Yo";
                    break;
                case '6':
                    ghetto += "Dis";
                    break;
                case '7':
                    ghetto += "Hood";
                    break;
                case '8':
                    ghetto += "Jam";
                    break;
                case '9':
                    ghetto += "Mack";
                    break;
            }
        }

        System.out.println(ghetto);
    }
}