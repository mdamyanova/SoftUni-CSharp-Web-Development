namespace DirectoryTraversal
{
    using System;

    public class TraversalMain
    {
        static void Main()
        {
            var directoryProvider = new DirectoryProvider();
            var traverser = new DirectoryTraverser(@"C:\", directoryProvider);

            var children = traverser.GetChildDirectories();
            foreach (var child in children)
            {
                Console.WriteLine(child);
            }

            Console.WriteLine(traverser.CurrentDirectory);
        }
    }
}
