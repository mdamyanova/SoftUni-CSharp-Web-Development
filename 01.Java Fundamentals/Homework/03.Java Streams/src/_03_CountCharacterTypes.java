//Write a program that reads a list of words from the file words.txt and finds the count of vowels,
// consonants and other punctuation marks.

import java.io.*;
import java.util.ArrayList;

public class _03_CountCharacterTypes {

    public static void main(String[] args) {

        try (BufferedReader reader = new BufferedReader(
                new FileReader(
                        new File("resources//words.txt")))) {

            ArrayList<String> words = new ArrayList<>();
            String line = reader.readLine();
            while (line != null) {
                words.add(line);
                line = reader.readLine();
            }
            reader.close();

            try (PrintWriter writer = new PrintWriter(
                    new FileWriter(
                            new File("resources//count-chars.txt")))) {
                int vowels = 0;
                int consonants = 0;
                int punctuation = 0;
                int uselessWhitespaces = 0;

                for (int i = 0; i < words.size(); i++) {
                    for (int j = 0; j < words.get(i).length(); j++) {
                        switch (words.get(i).charAt(j)) {
                            case 'a':
                            case 'e':
                            case 'i':
                            case 'o':
                            case 'u':
                                vowels++;
                                break;
                            case '!':
                            case ',':
                            case '.':
                            case '?':
                                punctuation++;
                                break;
                            case ' ':
                                uselessWhitespaces++;
                                break;
                            default:
                                consonants++;
                                break;
                        }
                    }
                }
                writer.println("Vowels: " + vowels);
                writer.println("Consonants: " + consonants);
                writer.println("Punctuation: " + punctuation);

                writer.close();
            }
        } catch (IOException ioe) {

        }
    }
}