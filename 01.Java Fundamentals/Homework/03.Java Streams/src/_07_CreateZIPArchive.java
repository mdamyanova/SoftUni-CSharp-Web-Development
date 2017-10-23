//Write a program that reads three txt files words.txt,
// count-chars.txt and lines.txt and create a zip archive
// named text-files.zip. Use FileOutputStream, ZipOutputStream, and FileInputStream.

import java.io.*;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

public class _07_CreateZIPArchive {

    public static void main(String[] args) throws IOException {

        ZipOutputStream zip = new ZipOutputStream(
                new FileOutputStream(
                        "resources//text-files.zip"));

        FileInputStream input = new FileInputStream(
                "resources//words.txt");
        byte[] buffer = new byte[4092];

        zip.putNextEntry(new ZipEntry("words.txt"));
        while (true){
            int bytesRead = input.read(buffer);
            if (bytesRead == -1){
                break;
            }
           zip.write(buffer, 0, bytesRead);
        }
        zip.closeEntry();

        zip.putNextEntry(new ZipEntry("count-chars.txt"));
        input = new FileInputStream(
                "resources//count-chars.txt");
        while (true){
            int bytesRead = input.read(buffer);
            if (bytesRead == -1){
                break;
            }
            zip.write(buffer, 0, bytesRead);
        }
        zip.closeEntry();

        zip.putNextEntry(new ZipEntry("lines.txt"));
        input = new FileInputStream(
                "resources//lines.txt");
        while (true){
            int bytesRead = input.read(buffer);
            if (bytesRead == -1){
                break;
            }
            zip.write(buffer, 0, bytesRead);
        }
        zip.closeEntry();

        zip.finish();
        zip.close();

    }
}