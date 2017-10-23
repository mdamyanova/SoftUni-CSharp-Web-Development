//Write a program that reads a text file and prints on
// the console the sum of the ASCII symbols of each of
// its lines. Use BufferedReader in combination with
// FileReader.

import java.io.*;

public class _01_SumLines {

    public static void main(String[] args) {

        try {
            FileReader file = new FileReader("resources//text.txt");
            BufferedReader reader = new BufferedReader(file);
            String line = reader.readLine();

            while(line != null){
                int counter = 0;
                for (int i = 0; i < line.length(); i++) {
                    counter += line.charAt(i);
                }
                System.out.println(counter);
                line = reader.readLine();
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}