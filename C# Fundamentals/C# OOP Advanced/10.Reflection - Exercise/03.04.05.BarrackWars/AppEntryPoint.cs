using _03._04._05.BarrackWars.Contracts;
using _03._04._05.BarrackWars.Core;
using _03._04._05.BarrackWars.Core.Factories;
using _03._04._05.BarrackWars.Data;

namespace _03._04._05.BarrackWars
{
    public class AppEntryPoint
    {
        public static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
