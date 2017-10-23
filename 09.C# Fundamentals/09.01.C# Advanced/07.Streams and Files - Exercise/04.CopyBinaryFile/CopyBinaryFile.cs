using System.IO;

namespace _04.CopyBinaryFile
{
    public class CopyBinaryFile
    {
        public static void Main()
        {
            const string image = "../../Duck.jpg";
            const string copied = "../../copied.txt";

            var read = new FileStream(image, FileMode.Open);
            var write = new FileStream(copied, FileMode.Create);

            using (read)
            {
                using (write)
                {
                    var buffer = new byte[4096];
                    while (true)
                    {
                        var bytesRead = read.Read(buffer, 0, buffer.Length);

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
}