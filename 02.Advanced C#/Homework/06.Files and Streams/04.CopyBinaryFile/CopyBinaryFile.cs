//Write a program that copies the contents of a binary file(e.g.image, video, etc.) 
//to another using FileStream. You are not allowed to use the File class or similar helper classes.

using System.IO;

class CopyBinaryFile
{
    static void Main()
    {
        string image = "Duck.jpg";
        string copied = "copied.txt";

        FileStream read = new FileStream(image, FileMode.Open);
        FileStream write = new FileStream(copied, FileMode.Create);

        using (read)
        {
            using (write)
            {
                var buffer = new byte[4096];
                while (true)
                {
                    int bytesRead = read.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    write.Write(buffer, 0, bytesRead);
                   
                }
            }
        }
    }
}
