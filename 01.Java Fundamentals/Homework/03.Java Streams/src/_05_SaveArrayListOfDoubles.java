//Write a program that saves and loads the information from an
// ArrayList to a file using ObjectInputStream, ObjectOutputStream.
// Set the name of the new file as doubles.list

import java.io.*;
import java.util.ArrayList;

public class _05_SaveArrayListOfDoubles {

    public static void main(String[] args) throws IOException, ClassNotFoundException {

        ArrayList<Double> doubles = new ArrayList<>();
        doubles.add(1.3);
        doubles.add(5.11);
        doubles.add(9.10);

        ObjectOutputStream oos = new ObjectOutputStream(
                                    new BufferedOutputStream(
                                        new FileOutputStream(
                                            "resources//doubles.list.txt")));

        oos.writeObject(doubles);
        oos.close();

        ObjectInputStream ois = new ObjectInputStream(
                                   new BufferedInputStream(
                                       new FileInputStream(
                                           "resources//doubles.list.txt")));

        System.out.println("List doubles: " + ois.readObject());
        ois.close();
    }
}