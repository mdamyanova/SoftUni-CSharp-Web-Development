using BashSoft.Contracts;
using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft
{
    public class Launcher
    {
        public static void Main()
        {
            var tester = new Tester();
            IDirectoryManager manager = new IOManager();
            var repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, manager);
            IReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}