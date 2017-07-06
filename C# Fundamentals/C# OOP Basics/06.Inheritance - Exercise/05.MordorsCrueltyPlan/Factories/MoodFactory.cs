using _05.MordorsCrueltyPlan.Models;
using _05.MordorsCrueltyPlan.Models.Moods;

namespace _05.MordorsCrueltyPlan.Factories
{
    public abstract class MoodFactory
    {
        public static Mood ProduceMood(int happiness)
        {
            if (happiness < -5)
                return new Angry();

            if (happiness >= -5 && happiness < 0)
                return new Sad();

            if (happiness >= 0 && happiness < 15)
                return new Happy();

            return new JavaScript();
        }
    }
}