

namespace DirectoryTraversal.Tests
{
    using System.Runtime.Remoting.Messaging;

    public class FakeDirectoryProviderUnsortedPaths : IDirectoryProvider
    {
        public string[] GetDirectories(string path)
        {
            return new string[] { "obj", "bin", "bbin", "assets", "Assets" };
        }
    }
}
