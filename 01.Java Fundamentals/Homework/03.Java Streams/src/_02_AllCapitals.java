//Write a program that reads a text file and changes the casing of all letters to upper.
// The file should be overwritten. Use BufferedReader, FileReader, FileWriter, and PrintWriter.

import java.io.*;
import java.util.ArrayList;

public class _02_AllCapitals {

    public static void main(String[] args) {

        try(
            BufferedReader reader = new BufferedReader(new FileReader(new File("resources//text.txt"))))
        {
            ArrayList<String> list = new ArrayList<>();
            String line = reader.readLine();

            while(line != null){
                list.add(line);
                line = reader.readLine();
            }
            reader.close();
            try(PrintWriter writer = new PrintWriter(new FileWriter(new File("resources//text.txt"), false), false)){
                for (int i = 0; i < list.size(); i++) {
                    writer.write(list.get(i).toUpperCase());
                    writer.println();
                }
                writer.close();
            }
        }
        catch (IOException ioe){

        }
    }
}