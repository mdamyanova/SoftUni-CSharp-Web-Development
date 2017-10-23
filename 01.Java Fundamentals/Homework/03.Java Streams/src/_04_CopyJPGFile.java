//Write a program that copies the contents of a .jpg file to another using
// FileInputStream, FileOutputStream, and byte[] buffer. Set the name of
// the new file as my-copied-picture.jpg.

import java.io.*;

public class _04_CopyJPGFile {

    public static void main(String[] args) throws IOException {
        FileInputStream fis = new FileInputStream("resources//be-awesome.jpg");
        FileOutputStream fos = new FileOutputStream("resources//my-copied-picture.jpg");

        byte[] buffer = new byte[4096];
        while (true){
            int bytesRead = fis.read(buffer);
            if (bytesRead == -1){
                break;
            }
            fos.write(buffer, 0, bytesRead);
        }

        fis.close();
        fos.close();
    }
}