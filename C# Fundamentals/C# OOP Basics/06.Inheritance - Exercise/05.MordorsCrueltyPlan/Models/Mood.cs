namespace _05.MordorsCrueltyPlan.Models
{
    public abstract class Mood
    {
        public string Type => this.GetType().Name;

        public override string ToString()
        {
            return this.Type;
        }
    }
}