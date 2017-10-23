namespace DirectoryTraversal.Tests
{
    public class FakeDirectoryProviderComplexPaths : IDirectoryProvider
    {
        public string[] GetDirectories(string path)
        {
            return new string[] { @"D:\bin\obj\Assets", @"C:\asdasda\asdsad\bin"};
        }
    }
}