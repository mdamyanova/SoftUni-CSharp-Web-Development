namespace _02.SliceFile
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            var path = Console.ReadLine();
            var destination = Console.ReadLine();
            var pieces = int.Parse(Console.ReadLine());

            SliceAsync(path, destination, pieces);

            Console.WriteLine("Anything else?");
            while (true)
            {
                Console.ReadLine();
            }
        }

        private static void Slice(string sourceFile, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                var fileInfo = new FileInfo(sourceFile);
                var partLength = (source.Length / parts) + 1;
                var currentByte = 0;

                for (int currentPart = 1; currentPart <= parts; currentPart++)
                {
                    var filePath = string.Format("{0}/Part-{1}{2}", destinationPath, currentPart, fileInfo.Extension);

                    using (var destination = new FileStream(filePath, FileMode.Create))
                    {
                        var buffer = new byte[4096];

                        while (currentByte <= partLength * currentPart)
                        {
                            var readBytesCount = source.Read(buffer, 0, buffer.Length);

                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }
            }

            Console.WriteLine("Slice complete.");
        }

        private static void SliceAsync(string sourceFile, string destinationPath, int parts)
        {
            Task.Run(() =>
            {
                Slice(sourceFile, destinationPath, parts);
            });
        }
    }
}