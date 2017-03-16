using System;
using Gringotts.Data;
using System.Linq;

namespace Gringotts
{
    public class Startup
    {
        public static void Main()
        {
            var context = new GringottsContext();

            //19. Deposits sum for Olivander family
            //DepositsSumForOlivanderFamily(context);

            //20. Deposits filter
            //DepositsFilter(context);   
        }

        private static void DepositsSumForOlivanderFamily(GringottsContext context)
        {
            var depositGroups = context.WizzardDeposits.Where(c => c.MagicWandCreator == "Ollivander family").GroupBy(c => c.DepositGroup).Select(c => new { DepositGroup = c.Key, Sum = c.Sum(b => b.DepositAmount) }).ToList();

            foreach (var depositGroup in depositGroups)
            {
                Console.WriteLine($"{depositGroup.DepositGroup} - {depositGroup.Sum}");
            }
        }

        private static void DepositsFilter(GringottsContext context)
        {
            var deposits = context.WizzardDeposits.Where(c => c.MagicWandCreator == "Ollivander family").GroupBy(c => c.DepositGroup).Select(c => new { DepositGroup = c.Key, Sum = c.Sum(b => b.DepositAmount) }).OrderByDescending(c => c.Sum).Where(c => c.Sum < 150000).ToList();
            foreach (var deposit in deposits)
            {
                Console.WriteLine($"{deposit.DepositGroup} - ${deposit.Sum}");
            }
        }
    }
}