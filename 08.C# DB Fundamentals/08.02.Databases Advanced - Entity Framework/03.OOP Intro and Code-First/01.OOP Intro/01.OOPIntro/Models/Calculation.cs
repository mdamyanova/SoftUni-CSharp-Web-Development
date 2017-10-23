using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.OOPIntro.Models
{
    class Calculation
    {
        private const double PlanckConstant = 6.62606896e-34;
        private const double Pi = Math.PI;

        public static double GetPlanckConstant()
        {
            const double result = PlanckConstant / (2 * Pi);
            return result;
        }
    }
}
